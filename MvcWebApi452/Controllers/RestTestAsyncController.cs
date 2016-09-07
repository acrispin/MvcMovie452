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
    /// <summary>
    /// https://www.exceptionnotfound.net/using-async-and-await-in-asp-net-what-do-these-keywords-mean/
    /// </summary>
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

        /// <summary>
        /// /api/test/async2
        /// </summary>
        /// <returns></returns>
        [Route("async2")]
        [HttpGet]
        public async Task<IHttpActionResult> testAsync2()
        {
            var dict = new Dictionary<string, object>() { { "rs", true }, { "msg", "" } };
            Stopwatch watch = new Stopwatch();
            watch.Start();
            ContentManagement service = new ContentManagement();
            var contentTask = service.GetContentAsync2();
            var countTask = service.GetCountAsync2();
            var nameTask = service.GetNameAsync2();
            var content = await contentTask;
            var count = await countTask;
            var name = await nameTask;
            watch.Stop();
            dict["msg"] = watch.ElapsedMilliseconds;
            return Ok(dict);
        }

        /// <summary>
        /// /api/test/async3
        /// </summary>
        /// <returns></returns>
        [Route("async3")]
        [HttpGet]
        public async Task<IHttpActionResult> testAsync3()
        {
            var dict = new Dictionary<string, object>() { { "rs", true }, { "msg", "" }, { "time", "" } };
            Stopwatch watch = new Stopwatch();
            watch.Start();
            ContentManagement service = new ContentManagement();
            var rsTask = service.normalMethodAsync();
            var rsTask2 = service.normalMethodAsync2();
            var rs = await rsTask;
            var rs2 = await rsTask2;
            watch.Stop();
            dict["time"] = watch.ElapsedMilliseconds;
            dict["msg"] = rs + " - " + rs2;
            return Ok(dict);
        }

        /// <summary>
        /// /api/test/async4
        /// </summary>
        /// <returns></returns>
        [Route("async4")]
        [HttpGet]
        public async Task<IHttpActionResult> testAsync4()
        {
            var dict = new Dictionary<string, object>() { { "rs", true }, { "msg", "" }, { "time", "" } };
            Stopwatch watch = new Stopwatch();
            watch.Start();
            ContentManagement service = new ContentManagement();
            var rsTask = service.normalMethodAsync();
            var rsTask2 = service.normalMethodAsyncError();
            var rs = await rsTask;
            var rs2 = await rsTask2;
            watch.Stop();
            dict["time"] = watch.ElapsedMilliseconds;
            dict["msg"] = rs + " - " + rs2;
            return Ok(dict);
        }

        /// <summary>
        /// /api/test/async5
        /// controlando el error de testAsync4
        /// </summary>
        /// <returns></returns>
        [Route("async5")]
        [HttpGet]
        public async Task<IHttpActionResult> testAsync5()
        {
            var dict = new Dictionary<string, object>() { { "rs", true }, { "msg", "" }, { "time", "" } };
            Stopwatch watch = new Stopwatch();
            watch.Start();
            try
            {
                ContentManagement service = new ContentManagement();
                var rsTask = service.normalMethodAsync();
                var rsTask2 = service.normalMethodAsyncError();
                var rs = await rsTask;
                var rs2 = await rsTask2;
                watch.Stop();
                dict["time"] = watch.ElapsedMilliseconds;
                dict["msg"] = rs + " - " + rs2;
            }
            catch (Exception ex)
            {
                watch.Stop();
                dict["rs"] = false;
                dict["msg"] = ex.Message;
                dict["time"] = watch.ElapsedMilliseconds;
            }
            
            return Ok(dict);
        }
    }
}
