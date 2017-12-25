using System;
using System.Configuration;

namespace ConsulServiceWrapper
{
  public class ServiceInstanceCollection : ConfigurationElementCollection
  {
    protected override string ElementName => "instance";

    public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.BasicMap;

    public ServiceInstance this[int index] => BaseGet(index) as ServiceInstance;

    protected override ConfigurationElement CreateNewElement()
    {
      return new ServiceInstance();
    }

    protected override object GetElementKey(ConfigurationElement element)
    {
      return ((ServiceInstance)element).Name;
    }

    protected override bool IsElementName(string elementName)
    {
      return !String.IsNullOrEmpty(elementName) && elementName == ElementName;
    }
  }
}