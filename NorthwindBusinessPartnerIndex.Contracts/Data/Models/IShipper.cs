namespace NorthwindBusinessPartnerIndex.Contracts.Data.Models
{
    public interface IShipper : IDataEntity
    {
        int ShipperId { get; set; }
        string Phone { get; set; }
    }
}
