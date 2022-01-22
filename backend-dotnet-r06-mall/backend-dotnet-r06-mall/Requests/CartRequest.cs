using System;
using System.Collections.Generic;

namespace backend_dotnet_r06_mall.Requests
{
    public class CartRequest
    {
        public List<Cart_ProductRequest> cartItems { get; set; }
        public DiaChiRequest shippingAddress { get; set; }
        public string paymentMethod { get; set; }
    }
}