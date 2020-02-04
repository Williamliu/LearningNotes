using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebCore1
{
    public class Program
    {
public static void Main(string[] args)
{
            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            catch(Exception err)
            {
                var er = err;
            }
}

public static IWebHostBuilder CreateWebHostBuilder(string[] args) => 
    WebHost.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        var env = hostingContext.HostingEnvironment;
        config.SetBasePath(env.ContentRootPath)
        .AddInMemoryCollection( new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("database.ssl", "true"),
            new KeyValuePair<string, string>("database.port", "443"),
            new KeyValuePair<string, string>("database.persit", "Permission"),
            new KeyValuePair<string, string>("database.transport", "Stream")
        })
        .AddJsonFile(path: "lwh.json", optional: false, reloadOnChange: true)
        .AddJsonFile(path: "lwh1.json", optional: false, reloadOnChange: true)
        .AddXmlFile(path: "lwh.xml", optional: false, reloadOnChange: true);
    })
    .UseStartup<Startup>();
}

}
