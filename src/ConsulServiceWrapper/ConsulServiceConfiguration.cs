using System.Configuration;

namespace ConsulServiceWrapper
{
  public class ConsulServiceConfiguration : ConfigurationSection
  {
    [ConfigurationProperty("", IsDefaultCollection = true, IsKey = false, IsRequired = true)]
    public ServiceInstanceCollection Instances
    {
      get { return (ServiceInstanceCollection)this[""]; }
      set { this[""] = value; }
    }

    [ConfigurationProperty("executable", IsRequired = true)]
    public string Executable
    {
      get { return (string)this["executable"]; }
      set { this["executable"] = value; }
    }

    [ConfigurationProperty("serviceName", IsRequired = false, DefaultValue = "ConsulServiceWrapper")]
    public string ServiceName
    {
      get { return (string)this["serviceName"]; }
      set { this["serviceName"] = value; }
    }

    [ConfigurationProperty("serviceDisplayName", IsRequired = false, DefaultValue = "ConsulServiceWrapper")]
    public string ServiceDisplayName
    {
      get { return (string)this["serviceDisplayName"]; }
      set { this["serviceDisplayName"] = value; }
    }

    [ConfigurationProperty("serviceDescription", IsRequired = false, DefaultValue = "ConsulServiceWrapper")]
    public string ServiceDescription
    {
      get { return (string)this["serviceDescription"]; }
      set { this["serviceDescription"] = value; }
    }
  }
}