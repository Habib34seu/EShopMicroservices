
namespace BuildingBlocks.Pagination;

public class PaginatedResult<TEntiry>
    (int pageIndex, int pageSize, long count, IEnumerable<TEntiry> data) 
    where TEntiry : class
{
    public int PageIndex { get; } = pageIndex;
    public int PageSize { get; } = pageSize;
    public long Count { get; } = count;
    public IEnumerable<TEntiry> Data { get; } = data;
}
