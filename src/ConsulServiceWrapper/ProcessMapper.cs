using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsulServiceWrapper
{
  public class ProcessMapper
  {
    public ProcessStartInfo GetProcessStartInfo(string executable, ServiceInstance instance)
    {
      if (string.IsNullOrWhiteSpace(executable))
      {
        executable = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "consul.exe");
      }
      if (!Path.IsPathRooted(executable))
      {
        executable = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, executable);
      }

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