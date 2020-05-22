namespace NorthwindBusinessPartnerIndex.Contracts.Data.Models
{
    public interface IDataEntity
    {
        string Id { get; }
        string CompanyName { get; set; }
    }
}
