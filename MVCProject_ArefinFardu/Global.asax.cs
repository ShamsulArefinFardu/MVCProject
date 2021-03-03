using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using MVCProject_ArefinFardu.Models;
using MVCProject_ArefinFardu.Models.ViewModel;
using AutoMapper;

namespace MVCProject_ArefinFardu
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            Mapper.Initialize(config =>
            {
                config.CreateMap<CategoryVM, Category>();
                config.CreateMap<Category, CategoryVM>();
            });
        }
    }
}
