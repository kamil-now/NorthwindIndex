using NorthwindBusinessPartnerIndex.Contracts.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindBusinessPartnerIndex.Service.Data.Models
{
    public class Shipper: IShipper
    {
        [NotMapped]
        public string Id => ShipperId.ToString();

        [Required]
        [Key]
        public int ShipperId { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(40)]
        [Required]
        public string CompanyName { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(24)]
        public string Phone { get; set; }
    }
}
