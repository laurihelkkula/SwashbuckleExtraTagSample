using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwashbuckleExtraTagSample.ExtraTags
{
  [AttributeUsage(AttributeTargets.Method)]
  public class SwaggerExtraTagAttribute : Attribute
  {
    public SwaggerExtraTagAttribute(string tag)
    {
      Tag = tag;
    }

    public string Tag { get; }
  }
}