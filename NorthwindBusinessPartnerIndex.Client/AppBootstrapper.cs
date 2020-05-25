using Autofac;
using Caliburn.Micro;
using NorthwindBusinessPartnerIndex.Client.Services;
using NorthwindBusinessPartnerIndex.Client.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace NorthwindBusinessPartnerIndex.Client
{
    public class AppBootstrapper : BootstrapperBase
    {
        public IContainer Container { get; private set; }
        public AppBootstrapper()
        {
            //var hostExePath = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\\NorthwindBusinessPartnerIndex.Host\\bin\\Debug\\NorthwindBusinessPartnerIndex.Host.exe";
            //Process.Start(hostExePath);

            ViewLocator.AddSubNamespaceMapping("NorthwindBusinessPartnerIndex.Client.UI.ViewModels", "NorthwindBusinessPartnerIndex.Client.UI.Views");

            Container = BuildContainer();

            Initialize();
        }
        private IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ShellViewModel>().AsSelf().SingleInstance();
            builder.RegisterType<MainViewModel>().AsSelf().SingleInstance();
            builder.RegisterType<BusinessPartnerListViewModel>().AsSelf().SingleInstance();
            builder.RegisterType<BusinessPartnerDataViewModel>().AsSelf().SingleInstance();

            builder.RegisterType<CustomerService>().AsSelf().SingleInstance();
            builder.RegisterType<ShipperService>().AsSelf().SingleInstance();
            builder.RegisterType<SupplierService>().AsSelf().SingleInstance();
            builder.RegisterType<BusinessPartnerService>().AsSelf().SingleInstance();
            builder.Register<IWindowManager>(c => new WindowManager()).InstancePerLifetimeScope();
            builder.Register<IEventAggregator>(c => new EventAggregator()).InstancePerLifetimeScope();

            return builder.Build();
        }
        protected override object GetInstance(Type serviceType, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                if (Container.IsRegistered(serviceType))
                    return Container.Resolve(serviceType);
            }
            else
            {
                if (Container.IsRegistered(serviceType))
                    return Container.Resolve(serviceType);
            }
            throw new Exception(string.Format("Could not locate any instances of contract {0}.", key ?? serviceType.Name));
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return Container.Resolve(typeof(IEnumerable<>).MakeGenericType(serviceType)) as IEnumerable<object>;
        }

        protected override void BuildUp(object instance)
        {
            Container.InjectProperties(instance);
        }
        protected override void OnStartup(object sender, StartupEventArgs args)
        {
            DisplayRootViewFor<ShellViewModel>(new Dictionary<string, object>()
                {
                    { nameof(Window.Title), "Northwind Business Partner Index" }
                });
        }
        protected override void OnExit(object sender, EventArgs e)
        {
            base.OnExit(sender, e);

        }
    }
}
