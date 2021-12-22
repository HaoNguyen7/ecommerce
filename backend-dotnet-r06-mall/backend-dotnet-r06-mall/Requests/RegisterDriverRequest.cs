namespace backend_dotnet_r06_mall.Requests
{
    public class RegisterDriverRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string LicenseId { get; set; }
        public string CardId { get; set; }
    }
}
