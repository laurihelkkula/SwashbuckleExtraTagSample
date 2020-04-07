using System.Web.Http;
using System.Web.Http.Description;
using WebActivatorEx;
using SwashbuckleExtraTagSample;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using SwashbuckleExtraTagSample.ExtraTags;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace SwashbuckleExtraTagSample
{
    public class SwaggerConfig
    {
        public static void Register()
        {

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "SwashbuckleExtraTagSample");

                        c.OperationFilter<ExtraTagsFilter>();
                        c.DocumentFilter<ExtraTagsDescriptionFilter>();
                    })
                .EnableSwaggerUi();
        }
    }

}
