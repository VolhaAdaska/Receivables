using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Microsoft.Owin.Security;
using Receivables.Bll.Interfaces;
using Receivables.Bll.Services;
using Receivables.Dal.Context;
using Receivables.Dal.Interfaces;
using Receivables.Dal.Repositories;
using System.Reflection;
using System.Web;

namespace Receivables
{
    public static class AutofacConfig
    {
        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
            builder.RegisterType<StoreService>().As<IStoreService>().InstancePerRequest();
            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerRequest();
            builder.RegisterType<AgreementService>().As<IAgreementService>().InstancePerRequest();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerRequest();
        }

        private static void RegisterRepository(ContainerBuilder builder)
        {
            builder.RegisterType<StoreRepository>().As<IStoreRepository>().InstancePerRequest();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerRequest();
            builder.RegisterType<AgreementRepository>().As<IAgreementRepository>().InstancePerRequest();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
        }

        private static void RegisterContext(ContainerBuilder builder)
        {
            builder.RegisterType<ReceivablesContext>().AsSelf().InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();
        }

        private static void RegisterAutomapper(ContainerBuilder builder)
        {
            builder.RegisterType<AutomapperConfig>().AsSelf().SingleInstance();
            builder.Register(c => new MapperConfiguration(cfg => cfg.AddProfile(c.Resolve<AutomapperConfig>()))).AsSelf().SingleInstance();
            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();
        }
        private static Assembly GetWebEntryAssembly()
        {
            var proxyApplicationInstance = HttpContext.Current.ApplicationInstance;
            var proxyApplicationInstanceType = proxyApplicationInstance.GetType();
            var baseApplicationInstanceType = proxyApplicationInstanceType.BaseType;
            return baseApplicationInstanceType?.Assembly;
        }

        public static ContainerBuilder ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            var entryAssembly = GetWebEntryAssembly();
            builder.RegisterControllers(entryAssembly);
            RegisterServices(builder);
            RegisterContext(builder);
            RegisterRepository(builder);
            RegisterAutomapper(builder);
            return builder;
        }
    }
}