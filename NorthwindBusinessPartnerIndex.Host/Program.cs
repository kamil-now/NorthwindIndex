using NorthwindBusinessPartnerIndex.Data;
using System;

namespace NorthwindBusinessPartnerIndex.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var _unitOfWork = new UnitOfWork(new NorthwindContext());
            var customerHost = new BusinessPartnerServiceHost(_unitOfWork, typeof(BusinessPartnerService));
            customerHost.Open();
            Console.WriteLine("Service is running");
            Console.Read();
        }
    }
}
