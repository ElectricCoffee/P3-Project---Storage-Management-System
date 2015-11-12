using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Inventory_Management_System
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}", // localhost:5000/api/Log/...
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
