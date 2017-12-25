using System.Configuration;

namespace ConsulServiceWrapper
{
  public class ServiceInstance : ConfigurationElement
  {
    [ConfigurationProperty("name", IsRequired = true)]
    public string Name
    {
      get { return (string)this["name"]; }
      set { this["name"] = value; }
    }

    [ConfigurationProperty("jsonFile", IsRequired = true)]
    public string ConfigurationPath
    {
      get { return (string)this["jsonFile"]; }
      set { this["jsonFile"] = value; }
    }

    [ConfigurationProperty("enableWebUI", IsRequired = true, DefaultValue = @"true")]
    public string EnableWebUI
    {
      get { return (string)this["enableWebUI"]; }
      set { this["enableWebUI"] = value; }
    }
  }
}