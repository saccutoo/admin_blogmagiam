using Autofac;
using Autofac.Integration.Mvc;
using BlogMaGiam.Controllers;
using BlogMaGiam.Services;
using System.Web.Mvc;
using IContainer = Autofac.IContainer;

namespace BlogMaGiam
{
    public static class RegisterDependencies
    {
        private static IContainer Container { get; set; }
        public static void Register()
        {
            var builder = new ContainerBuilder();
            //services
            //builder.RegisterType<CommonRepository>().InstancePerLifetimeScope();
            builder.RegisterType<NewService>().As<INewService>().InstancePerLifetimeScope();
            builder.RegisterType<TypeNewService>().As<ITypeNewService>().InstancePerLifetimeScope();
            builder.RegisterType<TypePromotionService>().As<ITypePromotionService>().InstancePerLifetimeScope();
            builder.RegisterType<StatusService>().As<IStatusService>().InstancePerLifetimeScope();
            builder.RegisterType<ClickMerchantService>().As<IClickMerchantService>().InstancePerLifetimeScope();
            builder.RegisterType<DashboardService>().As<IDashboardService>().InstancePerLifetimeScope();
            builder.RegisterType<MenuService>().As<IMenuService>().InstancePerLifetimeScope();
            builder.RegisterType<AuthenService>().As<IAuthenService>().InstancePerLifetimeScope();
            builder.RegisterType<CouponService>().As<ICouponService>().InstancePerLifetimeScope();
            builder.RegisterType<MerchantService>().As<IMerchantService>().InstancePerLifetimeScope();
            //controller base
            builder.RegisterType<BaseController>();

            //controllers 
            builder.RegisterType<HomeController>();
            builder.RegisterType<NewController>();
            builder.RegisterType<ClickMerchantController>();
            builder.RegisterType<MenuController>();
            builder.RegisterType<AuthenController>();
            builder.RegisterType<CouponController>();
            //build all
            Container = builder.Build();

            //set dependency resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
        }
    }
}