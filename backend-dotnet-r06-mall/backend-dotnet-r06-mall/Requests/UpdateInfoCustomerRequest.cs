using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_dotnet_r06_mall.Requests
{
    public class UpdateInfoCustomerRequest
    {
        public string TenKhachHang { get; set; }
        public string? SoDienThoai { get; set; }
        public string? DiaChi { get; set; }
        public string? Cccd { get; set; }
        public string? STK { get; set; }
        public string? Vung { get; set; }
    }
}
