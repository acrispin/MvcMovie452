using MvcWebApi452.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MvcWebApi452.Controllers
{
    [RoutePrefix("api/test")]
    public class RestTestAsyncController : ApiController
    {
        /// <summary>
        /// /api/test/sync
        /// </summary>
        /// <returns></returns>
        [Route("sync")]
        [HttpGet]
        public IHttpActionResult testSync()
        {
            var dict = new Dictionary<string, object>() { { "rs", true }, { "msg", "" } };
            Stopwatch watch = new Stopwatch();
            watch.Start();
            ContentManagement service = new ContentManagement();
            var content = service.GetContent();
            var count = service.GetCount();
            var name = service.GetName();
            watch.Stop();
            dict["msg"] = watch.ElapsedMilliseconds;
            return Ok(dict);
        }

        /// <summary>
        /// /api/test/async
        /// </summary>
        /// <returns></returns>
        [Route("async")]
        [HttpGet]
        public async Task<IHttpActionResult> testAsync()
        {
            var dict = new Dictionary<string, object>() { { "rs", true }, { "msg", "" } };
            Stopwatch watch = new Stopwatch();
            watch.Start();
            ContentManagement service = new ContentManagement();
            var contentTask = service.GetContentAsync();
            var countTask = service.GetCountAsync();
            var nameTask = service.GetNameAsync();
            var content = await contentTask;
            var count = await countTask;
            var name = await nameTask;
            watch.Stop();
            dict["msg"] = watch.ElapsedMilliseconds;
            return Ok(dict);
        }
    }
}
