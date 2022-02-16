using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend_dotnet_r06_mall.Models
{
    public class Distributor
    {
        [Key]
        public int Id { get; set; } 
        public string DistributorName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Product> Product { get; set; }

    }
}
