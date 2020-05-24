using System.Runtime.Serialization;

namespace NorthwindBusinessPartnerIndex.Contracts.DataContracts
{
    [DataContract]
    public class ShipperDto : IBusinessPartner
    {
        [DataMember]
        public string Id
        {
            get => ShipperID.ToString();
            set
            {
                int.TryParse(value, out int result);
                ShipperID = result;
            }
        }

        [DataMember]
        public int ShipperID { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string Phone { get; set; }
    }
}
