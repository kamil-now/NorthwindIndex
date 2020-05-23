using NorthwindBusinessPartnerIndex.Data;
using System;

namespace NorthwindBusinessPartnerIndex.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var _unitOfWork = new UnitOfWork(new NorthwindContext());
            var customerHost = new CustomerServiceHost(_unitOfWork, typeof(CustomerService));
            customerHost.Open();
            var supplierHost = new SupplierServiceHost(_unitOfWork, typeof(SupplierService));
            supplierHost.Open();
            var shipperHost = new ShipperServiceHost(_unitOfWork, typeof(ShipperService));
            shipperHost.Open();
            Console.WriteLine("Service Hosted Sucessfully");
            Console.Read();
        }
    }
}
