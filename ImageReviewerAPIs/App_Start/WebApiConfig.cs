using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ImageReviewerAPIs
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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "GetUserPreferences",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "Preference", action = "GetUserPreferences", id = RouteParameter.Optional }
            );
            
            config.Routes.MapHttpRoute(
                name: "GetRandomImage",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { controller = "Preference", action = "GetRandomImage" }
            );
        }
    }
}
