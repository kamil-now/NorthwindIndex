using System.Runtime.Serialization;

namespace NorthwindBusinessPartnerIndex.Contracts.DataContracts
{
    [DataContract]
    public class ShipperDto : IBusinessPartner
    {
        [DataMember]
        public string Id => ShipperId.ToString();
        [DataMember]
        public int ShipperId { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string Phone { get; set; }
    }
}
