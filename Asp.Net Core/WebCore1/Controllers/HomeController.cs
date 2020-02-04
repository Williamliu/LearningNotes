using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.Options;

namespace WebCore1.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        public HomeController(IConfiguration con, MemoryConfigurationProvider mpd, IOptions<Database> mydb, IOptions<Mftp> myfp)
        {
            var mdd = con.GetSection("database").Get<Database>();
            iDB mdb = new iDB(con.GetSection("database"));
            var host = con.GetSection("database:host");
            var hchild = host.GetChildren();
            var myf = myfp.Value;
            
            var db = mydb.Value;
        }

[Route("[action]/{myu?}")]
public IActionResult Index([FromRoute] string myu)
{
    var url = myu;
    if(string.IsNullOrWhiteSpace(myu))
    {
        return RedirectPermanent("About");
    }
    return View();
}
        public IActionResult Error ()
        {
            return View();
        }
        public IActionResult Contact([FromRoute] string myurl)
        {
            var con = RouteData.Values["CONTROLLER"];
            var act = RouteData.Values["ACTion"];
            var myu = RouteData.Values["MYURL"];
            ViewBag.myu = myurl;

            return View();
        }
[Route("[action]/{yeep=Good}")]
public IActionResult About([FromRoute] string yeep)
{
    var yp = yeep;
    return View();
}
    }
}