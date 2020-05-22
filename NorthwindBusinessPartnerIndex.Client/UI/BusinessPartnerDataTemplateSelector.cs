
using System.Windows;
using System.Windows.Controls;

namespace NorthwindBusinessPartnerIndex.Client.UI
{
    public class BusinessPartnerDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return Application.Current.FindResource("CustomerDataTemplate") as DataTemplate;
            // TODO
            //switch (item)
            //{
            //    case Customer   c: return Application.Current.FindResource("CustomerDataTemplate") as DataTemplate;
            //    case Shipper    c: return Application.Current.FindResource("ShipperDataTemplate") as DataTemplate;
            //    case Supplier   c: return Application.Current.FindResource("SupplierDataTemplate") as DataTemplate;
            //    default: return null;
            //}

        }

    }
}
