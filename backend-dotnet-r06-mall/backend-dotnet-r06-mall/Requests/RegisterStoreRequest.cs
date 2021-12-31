using System.ComponentModel.DataAnnotations;

namespace backend_dotnet_r06_mall.Requests
{
    public class RegisterStoreRequest
    {
        public string Name { get; set; }
        public string StoreName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string CardId { get; set; }
        public string TaxId { get; set; }
        public string Description { get; set; }
    }
}
