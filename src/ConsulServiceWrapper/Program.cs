using System.Configuration;
using Topshelf;

namespace ConsulServiceWrapper
{
  class Program
  {
    public static void Main()
    {
      var configuration = (ConsulServiceConfiguration)ConfigurationManager.GetSection("consul");

      HostFactory.Run(x =>
      {
        x.RunAsLocalSystem();
        x.StartAutomatically();
        x.EnableShutdown();
        x.EnableServiceRecovery(c => c.RestartService(1));

        x.Service<ServiceWrapper>(s =>
       {
         s.ConstructUsing(name => new ServiceWrapper(configuration));
         s.WhenStarted(tc => tc.Start());
         s.WhenStopped(tc => tc.Stop());
       });

        x.SetDescription(configuration.ServiceDescription);
        x.SetDisplayName(configuration.ServiceDisplayName);
        x.SetServiceName(configuration.ServiceName);
      });
    }

  }
}
