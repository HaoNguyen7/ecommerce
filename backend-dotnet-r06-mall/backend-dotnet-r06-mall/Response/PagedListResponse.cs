namespace backend_dotnet_r06_mall.Response
{
    public class PagedListResponse<T>
    {
        public PagedList<T> data { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public int PageSize { get; set; }

        public PagedListResponse(PagedList<T> list)
        {
            data = list;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            HasNextPage = list.HasNextPage;
            HasPreviousPage = list.HasPreviousPage;
            PageSize = list.PageSize;
        }
    }
}