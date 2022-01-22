using System;
using System.Collections.Generic;

namespace backend_dotnet_r06_mall.Requests
{
    public class Cart_ProductRequest
    {
        public Guid product { get; set; }
        public int qty {get; set; }
    }
}