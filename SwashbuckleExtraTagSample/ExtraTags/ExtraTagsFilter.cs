using System;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace SwashbuckleExtraTagSample.ExtraTags
{
  public class ExtraTagsFilter : IOperationFilter
  {
    public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
    {
      var tags = apiDescription.ActionDescriptor
        .GetCustomAttributes<SwaggerExtraTagAttribute>(true)
        .Select(x => x.Tag)
        .ToArray();
      if (!tags.Any())
        return;

      if (operation.tags != null)
        operation.tags = operation.tags.Concat(tags).ToArray();
      else
        operation.tags = tags;

    }
  }
}