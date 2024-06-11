using System.Text.Json.Serialization;

namespace FinanceApp.Core.Responses;

public class PagedResponse<TData> : Response<TData>
{
    public int CurrentPage { get; set; }
    public int TotalCount { get; set; }
    public int PageSize { get; set; } = CoreConfiguration.DefaultPageSize;
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

    [JsonConstructor]
    public PagedResponse(
        TData? data,
        int totalCount,
        int currentPage = 1,
        int pageSize = CoreConfiguration.DefaultPageSize) 
        : base(data)
    {
        // Data = data;
        TotalCount = totalCount;
        CurrentPage = currentPage;
        PageSize = pageSize;
    }

    public PagedResponse(
        TData? data,
        int statusCode = CoreConfiguration.DefaultStatusCode,
        string? message = null)
        : base(data, statusCode, message)
    { }
}