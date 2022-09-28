using Dayana.Shared.Persistence.Models.Enums;

namespace Dayana.Shared.Infrastructure.Pagination;
public record PaginationFilter
{
    private const int MinPageNumber = 1;
    private const int MaxPageSize = 200;

    protected PaginationFilter(int pageNumber, int pageSize)
    {
        Page = pageNumber > 0 ? pageNumber : MinPageNumber;
        PageSize = pageSize > 0 && pageSize <= MaxPageSize ? pageSize : MaxPageSize;
    }

    protected PaginationFilter()
    {
    }

    public int Page { get; }
    public int PageSize { get; }
}

public record DefaultPaginationFilter : PaginationFilter
{
    public DefaultPaginationFilter(int pageNumber, int pageSize) : base(pageNumber, pageSize) { }
    public DefaultPaginationFilter() { }

    public string? keyword { get; init; }
    public int? IntValue { get; init; }
    public string? StringValue { get; init; }
    public IEnumerable<int>? IntValueList { get; init; }
    public IEnumerable<int>? StringValueList { get; init; }
    public int? CategoryId { get; init; }
    public int? Id { get; init; }
    public string? Name { get; init; }
    public string? Title { get; init; }
    public SortByEnum? SortBy { get; init; }
}


public record CustomaizedPaginationFilter<T1, T2, T3, T4> : PaginationFilter
{
    public CustomaizedPaginationFilter(int pageNumber, int pageSize) : base(pageNumber, pageSize) { }
    public CustomaizedPaginationFilter() { }

    public string? keyword { get; init; }
    public int? IntValue { get; init; }
    public string? StringValue { get; init; }
    public IEnumerable<int>? IntValueList { get; init; }
    public IEnumerable<int>? StringValueList { get; init; }
    public int? CategoryId { get; init; }
    public int? Id { get; init; }
    public string? Name { get; init; }
    public string? Title { get; init; }
    public SortByEnum? SortBy { get; init; }
    public T1 Value1 { get; init; }
    public T2 Value2 { get; init; }
    public T3 Value3 { get; init; }
    public T4 Value4 { get; init; }
}