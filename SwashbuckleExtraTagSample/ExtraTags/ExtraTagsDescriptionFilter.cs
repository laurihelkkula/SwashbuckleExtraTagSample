using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace SwashbuckleExtraTagSample.ExtraTags
{
  public class ExtraTagsDescriptionFilter : IDocumentFilter
  {

    public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
    {

      // Collect unique controllers and custom attributes in a dictionary
      var controllerNamesAndAttributes = apiExplorer.ApiDescriptions
        .Select(x => x.ActionDescriptor.ControllerDescriptor)
        .GroupBy(c=> c.ControllerType.FullName)
        .Select(group => new KeyValuePair<string, ICollection<SwaggerExtraTagDescriptionAttribute>>(group.Key,
          group.First().GetCustomAttributes<SwaggerExtraTagDescriptionAttribute>(true)));

      foreach (var entry in controllerNamesAndAttributes)
      {
        ApplySwaggerTagAttribute(swaggerDoc, entry.Value);
      }
    }

    private void ApplySwaggerTagAttribute(
      SwaggerDocument swaggerDoc,
      ICollection<SwaggerExtraTagDescriptionAttribute> swaggerTagAttributes)
    {
      if (swaggerTagAttributes == null) 
        return;
      if (!swaggerTagAttributes.Any())
        return;
      var newTags = swaggerTagAttributes.Select(x=>
        new Tag
        {
          name = x.Tag,
          description = x.Description,
        }
      );

      if (swaggerDoc.tags == null)
        swaggerDoc.tags = newTags.ToArray();
      else
        swaggerDoc.tags = swaggerDoc.tags.Concat(newTags).ToArray();
    }
  }
}