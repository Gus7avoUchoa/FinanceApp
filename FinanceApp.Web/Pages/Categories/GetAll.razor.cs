using FinanceApp.Core.Handlers;
using FinanceApp.Core.Models;
using FinanceApp.Core.Requests.Categories;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace FinanceApp.Web.Pages.Categories;

public partial class GetAllCategoriesPage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; } = false;
    public List<Category> Categories { get; set; } = [];

    #endregion

    #region Services

    [Inject]
    public ICategoryHandler Handler { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public IDialogService Dialog { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;

        try
        {
            var request = await Handler.GetAllAsync(new GetAllCategoriesRequest());

            if (request.IsSuccess)
                Categories = request.Data ?? [];
            else
                Snackbar.Add(request.Message, Severity.Error);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    #endregion

    #region Methods

    public async Task OnDeleteClickedAsync(long id, string title)
    {
        var result = await Dialog.ShowMessageBox("ATENÇÃO",
            $"Ao prosseguir a categoria {title} será removida. Deseja continuar?",
            yesText: "Excluir",
            cancelText: "Cancelar");

        if (result is true)
            await OnDeleteAsync(id, title);

        StateHasChanged();
    }

    private async Task OnDeleteAsync(long id, string title)
    {
        IsBusy = true;

        try
        {
            var request = await Handler.DeleteAsync(new DeleteCategoryRequest { Id = id });

            if (request.IsSuccess)
            {
                Snackbar.Add(request.Message, Severity.Success);
                Categories.RemoveAll(x => x.Id == id);
            }
            else
                Snackbar.Add(request.Message, Severity.Error);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    #endregion
}