using NorthwindBusinessPartnerIndex.Contracts.API;
using NorthwindBusinessPartnerIndex.Service.API;
using NorthwindBusinessPartnerIndex.Service.Data;
using NorthwindBusinessPartnerIndex.Service.Data.Models;
using System;
using System.Data.Entity;
using System.ServiceModel;
using System.Threading.Tasks;

namespace NorthwindBusinessPartnerIndex.Service
{
    class Program
    {
        static readonly string _url = "http://localhost:2222";
        static readonly UnitOfWork _unitOfWork = new UnitOfWork(new Northwind());
        static void Main(string[] args)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<Northwind>());
            
            var customerService = new TaskFactory().StartNew(() => OpenCustomerServiceHost());
            var supplierService = new TaskFactory().StartNew(() => OpenSupplierServiceHost());
            var shipperService = new TaskFactory().StartNew(() => OpenShipperServiceHost());

            Task.WaitAll(customerService, supplierService, shipperService);
            Console.ReadKey();
        }
        static void OpenCustomerServiceHost()
        {
            // TODO generic method
            Uri address = new Uri($"{_url}/Customers");
            ServiceHost host = new BusinessPartnerServiceHost(_unitOfWork, typeof(CustomerService), address);
            host.AddServiceEndpoint(typeof(ICustomerService), new BasicHttpBinding(), address);
            host.Open();
            Console.WriteLine("Customer service is running..");
        }
        static void OpenSupplierServiceHost()
        {
            Uri address = new Uri($"{_url}/Suppliers");
            ServiceHost host = new BusinessPartnerServiceHost(_unitOfWork, typeof(SupplierService), address);
            host.AddServiceEndpoint(typeof(ISupplierService), new BasicHttpBinding(), address);
            host.Open();
            Console.WriteLine("Supplier service is running..");
        }
        static void OpenShipperServiceHost()
        {
            Uri address = new Uri($"{_url}/Shippers");
            ServiceHost host = new BusinessPartnerServiceHost(_unitOfWork, typeof(ShipperService), address);
            host.AddServiceEndpoint(typeof(IShipperService), new BasicHttpBinding(), address);
            host.Open();
            Console.WriteLine("Shipper service is running..");
        }
    }
}
