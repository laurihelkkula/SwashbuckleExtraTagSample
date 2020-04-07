using System;

namespace SwashbuckleExtraTagSample.ExtraTags
{
  [AttributeUsage(AttributeTargets.Class)]
  public class SwaggerExtraTagDescriptionAttribute : Attribute
  {
    public SwaggerExtraTagDescriptionAttribute(string tag, string description = null)
    {
      Tag = tag;
      Description = description;
    }

    public string Description { get; }

    public string Tag { get; }
  }
}