using NorthwindBusinessPartnerIndex.Contracts.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusinessPartnerIndex.Client.API
{
    public class UnitOfWork
    {
        public CustomerService CustomersService { get; }
        public ShipperService ShippersService { get; }
        public SupplierService SuppliersService { get; }

        public UnitOfWork(CustomerService customersService, ShipperService shippersService, SupplierService suppliersService)
        {
            CustomersService = customersService;
            ShippersService = shippersService;
            SuppliersService = suppliersService;
        }
        public void AddOrUpdateAndCommit<T>(T entity)
        {
            switch (entity)
            {
                case Customer x:
                    CustomersService.AddOrUpdate(x);
                    CustomersService.Commit();
                    break;
                case Supplier x:
                    SuppliersService.AddOrUpdate(x);
                    SuppliersService.Commit();
                    break;
                case Shipper x:
                    ShippersService.AddOrUpdate(x);
                    ShippersService.Commit();
                    break;
                default: break;
            }
        }
    }
}
