using NorthwindBusinessPartnerIndex.Contracts.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindBusinessPartnerIndex.Service.Data.Models
{
    public class Customer : ICustomer
    {
        [NotMapped]
        public string Id => CustomerId;

        [Column(TypeName = "NCHAR")]
        [StringLength(5)]
        [Required]
        [Key]
        public string CustomerId { get; set; }


        [Column(TypeName = "NVARCHAR")]
        [StringLength(40)]
        [Required]
        public string CompanyName { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(30)]
        public string ContactName { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(30)]
        public string ContactTitle { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(60)]
        public string Address { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(15)]
        public string City { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(15)]
        public string Region { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(15)]
        public string Country { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(24)]
        public string Phone { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(24)]
        public string Fax { get; set; }
    }
}
