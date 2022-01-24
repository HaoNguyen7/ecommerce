namespace backend_dotnet_r06_mall.Requests
{
    public class GetInactiveStoreRequest
    {
        const int maxPageSize = 50;
        public int pageIndex { get; set; } = 1;
        private int _pageSize = 10;
        public int pageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
