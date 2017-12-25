using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsulServiceWrapper
{
  public class ProcessMapper
  {
    public ProcessStartInfo GetProcessStartInfo(string executable, ServiceInstance instance)
    {
      var arguments = GetProcessArguments(instance);

      return new ProcessStartInfo(executable, arguments)
      {
        UseShellExecute = false
      };
    }

    private string GetProcessArguments(ServiceInstance instance)
    {
      var configParameters = new Dictionary<string, string>();
      configParameters.Add("config-file", instance.ConfigurationPath);
      configParameters.Add("ui", instance.EnableWebUI);

      return " agent" + configParameters.Aggregate(" ", (acc, next) => string.Format("{0} \"-{1}={2}\"", acc, next.Key, next.Value));
    }
  }
}