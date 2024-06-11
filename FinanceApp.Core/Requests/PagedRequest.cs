namespace FinanceApp.Core.Requests;

public abstract class PagedRequest : Request
{
    public int PageNumber { get; set; } = CoreConfiguration.DefaultPageNumber;
    public int PageSize { get; set; } = CoreConfiguration.DefaultPageSize;
}