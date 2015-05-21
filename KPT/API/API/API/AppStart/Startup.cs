using System.Web.Http;
using Owin;
using Swashbuckle.Application;

namespace API.AppStart
{
	public class Startup
	{
		// This code configures Web API. The Startup class is specified as a type
		// parameter in the WebApp.Start method.
		public void Configuration(IAppBuilder appBuilder)
		{
			// Configure Web API for self-host. 
			var config = new HttpConfiguration();

            //Swashbuckle.Swagger.
                //Bootstrapper.Init(config);

            //config
            //    .EnableSwagger(c => c.SingleApiVersion("v1", "A title for your API"))
            //   .EnableSwaggerUi();   


			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
				);

			appBuilder.UseWebApi(config);
		}
	}
}