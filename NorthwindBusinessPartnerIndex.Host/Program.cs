using NorthwindBusinessPartnerIndex.Data;
using System;
using System.Linq;

namespace NorthwindBusinessPartnerIndex.Host
{
    class Program
    {
        static void Main()
        {
            using (var unitOfWork = new UnitOfWork(new NorthwindContext()))
            {
                using (var host = new BusinessPartnerServiceHost(unitOfWork, typeof(BusinessPartnerService)))
                {
                    host.Open();
                    Console.WriteLine($"Service is running on \n{string.Join("\n", host.BaseAddresses.Select(x => x.OriginalString).ToArray())}");
                    Console.Read();
                }
            }
        }
    }
}
