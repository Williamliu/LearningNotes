using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebCore1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        public IHostingEnvironment Env;
        public IConfiguration Config;
        public ValuesController(IHostingEnvironment env, IConfiguration config)
        {
            this.Env = env;
            this.Config = config;
        }
        // GET api/values
        [HttpGet("take")]
        public ActionResult<IEnumerable<string>> Get()
        {

            int a = 100;
            int b = 15;
            int c = a / b;
            return new string[] { $"a={a}", $"b={b}", $"a/b={c}" };
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> get(int id)
        {
            return $"Get id = {id}";
        }
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] StuModel stu)
        {
            return Ok(stu);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public string Put(int id)
        {
            int a = 100;
            int b = 20;
            int c = a / b;
            return $"Result: {a / b}  id={id}";

        }

        // DELETE api/values/5
        [Route("delete/{id}")]
        public async Task<string> Delete(int id)
        {
            return await Task.FromResult<string>($"Delete id={id}");
        }
    }

    public class StuModel
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public DateTime Birth { get; set; }
    }

    public class MyResult : IActionResult
    {
        Task IActionResult.ExecuteResultAsync(ActionContext context)
        {
            return new Task( null );
        }
    }
}
