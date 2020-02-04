using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WebCore1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //services.Configure<Database>(Configuration.GetSection("database"));
            //services.Configure<Mftp>(Configuration.GetSection("ftp"));
            var opb = new OptionsBuilder<Mftp>(services, "ftp");
            opb.Configure(p=> { p.server.host = "test test"; }); 
            services.AddOptions<Mftp>("ftp");

            iDB idb = new iDB(Configuration.GetSection("database"));
            var ifp = Configuration.GetSection("ftp");

            services.AddMvc(opt => {
                //opt.UseCentralRoutePrefix(new RouteAttribute("myapp/v2"));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

Dictionary<string, string> ms = new Dictionary<string, string> {
    {"database:memory", "64GB" },
    { "good:A:monday", "Mon1"},
    {"good:A:tue", "Tues1"},
    {"good:A:wed", "Wed1"},
    {"good:A:thu", "Thu1"},
    {"good:B:monday", "Mon1"},
    {"good:B:tue", "Tues2"},
    {"good:B:wed", "Wed2"},
    {"good:B:thu", "Thu2"},
    {"good:C:monday", "Mon3"},
    {"good:C:tue", "Tues3"},
    {"good:C:wed", "Wed3"},
    {"good:C:thu", "Thu3"},
    {"good:D:monday", "Mon4"},
    {"good:D:tue", "Tues4"},
    {"good:D:wed", "Wed4"},
    {"good:D:thu", "Thu4"}
                
};

/*
MyProvider myp = new MyProvider();
myp.Set("yourkey", "www.key.com");
MySource mys = new MySource(myp);
*/

MemoryConfigurationSource mmsource = new MemoryConfigurationSource();
mmsource.InitialData = ms;

IConfigurationBuilder builder = new ConfigurationBuilder();
builder.AddCustomSource(p=>p.UseSqlServer("Server=tcp:bartonedudb.database.windows.net,1433;Initial Catalog=bartonmaindb;Persist Security Info=False;User ID=dbuser;Password=Biniig2018$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

builder.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddInMemoryCollection(ms)
        .Add(mmsource)
        .AddJsonFile(path: "lwh.json", optional: false, reloadOnChange: true)
        .AddJsonFile(path: "lwh1.json", optional: false, reloadOnChange: true)
        .AddXmlFile(path: "lwh.xml", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

IConfigurationRoot configRoot = builder.Build();

//var website = configRoot.GetSection("database").GetValue(typeof(string), "host");
//var ftp = configRoot.GetSection("ftp").GetValue<string>("server");

Database db = configRoot.GetSection("database").Get<Database>();


Server ftpObj0 = configRoot.GetSection("ftp").GetValue<Server>("server");
Server ftpObj1 = configRoot.GetSection("ftp:server").Get<Server>();

iDB db1 = new iDB(configRoot.GetSection("database"));

Dictionary<string, GOOD> glist = configRoot.GetSection("good").Get<Dictionary<string, GOOD>>();
            
 services.AddSingleton<IConfiguration>(configRoot);
             
            MemoryConfigurationProvider mmprovider = new MemoryConfigurationProvider(mmsource);
            services.AddSingleton<MemoryConfigurationProvider>(mmprovider);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            HostingEnvironment ev1 = env as HostingEnvironment;
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/home/error");
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/home/error");
            }
            app.UseHttpsRedirection();
            //app.UseMvc();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Contact",
                    template: "about",
                    defaults: new { Controller = "home", Action = "about", yeep = "Sohu" }

                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{myurl}",
                    defaults: new { Controller = "Home", Action = "contact", myurl = "lwh.cshtml" }
                );
            });




        }
    }

    public static class MvcOptionsExtensions
    {
        public static void UseCentralRoutePrefix(this MvcOptions opts, IRouteTemplateProvider routeAttribute)
        {
            // 添加我们自定义 实现IApplicationModelConvention的RouteConvention
            opts.Conventions.Insert(0, new RouteConvention(routeAttribute));
        }
    }
    public class RouteConvention : IApplicationModelConvention
    {
        private readonly AttributeRouteModel _centralPrefix;

        public RouteConvention(IRouteTemplateProvider routeTemplateProvider)
        {
            _centralPrefix = new AttributeRouteModel(routeTemplateProvider);
        }

        //接口的Apply方法
        public void Apply(ApplicationModel application)
        {
            //遍历所有的 Controller
            foreach (var controller in application.Controllers)
            {
                // 已经标记了 RouteAttribute 的 Controller
                var matchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel != null).ToList();
                if (matchedSelectors.Any())
                {
                    foreach (var selectorModel in matchedSelectors)
                    {
                        // 在 当前路由上 再 添加一个 路由前缀
                        selectorModel.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(_centralPrefix,
                            selectorModel.AttributeRouteModel);
                    }
                }

                // 没有标记 RouteAttribute 的 Controller
                var unmatchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel == null).ToList();
                if (unmatchedSelectors.Any())
                {
                    foreach (var selectorModel in unmatchedSelectors)
                    {
                        // 添加一个 路由前缀
                        selectorModel.AttributeRouteModel = _centralPrefix;
                    }
                }
            }
        }
    }

    public class MyCon
    {
        public string website { get; set; }
        public Database DataBase { get; set; }
        public Mftp FTP { get; set; }
    }
    public class Database
    {
        public string host { get; set; }
        public string user { get; set; }
        public int pwd { get; set; }
        public string flag { get; set; }
        public string yeep { get; set; }
        public string memory { get; set; }
    }
public class Mftp
{
    public Server server { get; set; }
    public int uid { get; set; }
    public string password { get; set; }
    public string trans { get; set; }
}
public class Server
{
    public string host { get; set; }
    public string ip { get; set; }
    public int port { get; set; }
}
public class GOOD
{
    public string monday { get; set; }
    public string tue { get; set; }
    public string wed { get; set; }
    public string thu { get; set; }
}
public class iDB {
    public string host { get; set; }
    public string user { get; set; }
    public int pwd { get { return _pwd; } set { _pwd = value; } }
    private int _pwd;
    public string flag { get; set; }
    public string yeep { get; set; }
    public iDB(IConfiguration con)
    {
        this.host = con.GetValue<string>("host");
        this.user = con.GetValue<string>("user");
        this.pwd = con.GetValue<int>("pwd");
        this.flag = con.GetValue<string>("pwd");
        this.yeep = con.GetValue<string>("yeep");
    }
}

   public class MyProvider : ConfigurationProvider
    {
        public Action<DbContextOptionsBuilder> DBBuilderAction { get; set; }
        public MyProvider(Action<DbContextOptionsBuilder> dbBuildAction) {
            this.DBBuilderAction = dbBuildAction;
        }
        public override void Load()
        {
            DbContextOptionsBuilder dbbuilder = new DbContextOptionsBuilder();
            this.DBBuilderAction(dbbuilder);
            MyDB myDB = new MyDB(dbbuilder.Options);

            this.Data = myDB.Words.Where(p => p.Status == 1 && p.Deleted == 0).ToDictionary(t => t.Keyword, t => t.Word);
            base.Load();
        }
    }
    public class MySource: IConfigurationSource
    {
        public Action<DbContextOptionsBuilder> DBBuilderAction { get; set; }
        public MySource(Action<DbContextOptionsBuilder> dbBuildAction)
        {
            this.DBBuilderAction = dbBuildAction;
        }
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new MyProvider(this.DBBuilderAction);
        }
    }

    public class MyDB: DbContext
    {
        public MyDB() { }
        public MyDB(DbContextOptions dbo):base(dbo) { }
        public DbSet<Lang> Words { get; set; }
    }

    [Table("Language")]
    public class Lang
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Keyword { get; set; }
        [Column("lang_cn")]
        public string Word { get; set; }
        public byte Status { get; set; }
        public byte Deleted { get; set; }
    }

    public static class ConfigureBuilderExtension
    {
        public static IConfigurationBuilder AddCustomSource(this IConfigurationBuilder builder, Action<DbContextOptionsBuilder> dbBuilderAction)
        {
            return builder.Add(new MySource(dbBuilderAction));
        }
    }
}
