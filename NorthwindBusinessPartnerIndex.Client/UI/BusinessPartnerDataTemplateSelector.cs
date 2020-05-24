using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System.Windows;
using System.Windows.Controls;

namespace NorthwindBusinessPartnerIndex.Client.UI
{
    public class BusinessPartnerDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            switch (item)
            {
                case CustomerDto _: return Application.Current.FindResource("CustomerDataTemplate") as DataTemplate;
                case ShipperDto _: return Application.Current.FindResource("ShipperDataTemplate") as DataTemplate;
                case SupplierDto _: return Application.Current.FindResource("SupplierDataTemplate") as DataTemplate;
                default: return null;
            }

        }

    }
}
