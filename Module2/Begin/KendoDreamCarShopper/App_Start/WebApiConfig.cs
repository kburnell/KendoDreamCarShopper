using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;

namespace KendoDreamCarShopper {

    public static class WebApiConfig {

        public static void Register(HttpConfiguration config) {
            ConfigureFormatters(config);
            config.Routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "api/{controller}/{id}", defaults: new {id = RouteParameter.Optional});
        }

        private static void ConfigureFormatters(HttpConfiguration config) {
            JsonMediaTypeFormatter json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}