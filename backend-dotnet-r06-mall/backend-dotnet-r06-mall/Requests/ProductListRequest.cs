using System;
using System.Collections.Generic;

namespace backend_dotnet_r06_mall.Requests
{
    public class ProductListRequest
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

        public String categoryId { get; set; }
        public String shopId { get; set; }
        public string sortOrder { get; set; } = "date_desc";
        public string searchString { get; set; }
        public int status { get; set; }
    }

}