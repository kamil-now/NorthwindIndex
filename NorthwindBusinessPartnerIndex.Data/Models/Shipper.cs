using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindBusinessPartnerIndex.Data.Models
{
    public class Shipper : IBusinessPartner
    {
        [NotMapped]
        public string Id => ShipperID.ToString();
        public int ShipperID { get; set; }

        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }
    }
}
