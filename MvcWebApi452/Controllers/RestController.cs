using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Diagnostics;

namespace MvcWebApi452.Controllers
{
    /// <summary>
    /// https://www.exceptionnotfound.net/using-http-methods-correctly-in-asp-net-web-api/
    /// http://bitoftech.net/2014/03/05/new-asp-net-web-api-2-attribute-routing-tutorial/
    /// http://stackoverflow.com/questions/20226169/how-to-pass-json-post-data-to-web-api-method-as-object
    /// http://stackoverflow.com/questions/14407458/webapi-multiple-put-post-parameters
    /// http://stackoverflow.com/questions/24874490/pass-multiple-complex-objects-to-a-post-put-web-api-method
    /// http://www.dotnetcurry.com/aspnet/1278/aspnet-webapi-pass-multiple-parameters-action-method
    /// </summary>
    [RoutePrefix("api/rest2")]
    public class RestController : ApiController
    {
        /// <summary>
        /// /api/rest2
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpPost] // no necesita, por defecto es post
        public IHttpActionResult crear()
        {
            var dict = new Dictionary<string, object>() { { "rs", true }, { "msg", "OK creado" } };
            return Ok(dict);
        }

        /// <summary>
        /// /api/rest2
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpPut]
        public IHttpActionResult actualizar()
        {
            var dict = new Dictionary<string, object>() { { "rs", true }, { "msg", "OK actualizado" } };
            return Ok(dict);
        }

        /// <summary>
        /// /api/rest2
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpDelete]
        public IHttpActionResult eliminar()
        {
            var dict = new Dictionary<string, object>() { { "rs", true }, { "msg", "OK eliminado" } };
            return Ok(dict);
        }

        /// <summary>
        /// /api/rest2
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpGet]
        public IHttpActionResult listar()
        {
            var list = new List<Dictionary<string, object>>();
            list.Add(new Dictionary<string, object>() { { "name", "Juan" }, { "code", "123456" } });
            list.Add(new Dictionary<string, object>() { { "name", "Marco" }, { "code", "684313" } });
            list.Add(new Dictionary<string, object>() { { "name", "Pepe" }, { "code", "897138" } });
            list.Add(new Dictionary<string, object>() { { "name", "Anton" }, { "code", "235899" } });
            return Ok(list);
        }

        /// <summary>
        /// /api/rest2/test
        /// </summary>
        /// <returns></returns>
        [Route("test")]
        [HttpGet]
        public IHttpActionResult obtener()
        {
            var dict = new Dictionary<string, string>() { { "name", "Juan" }, { "code", "123456" } };
            // return Ok("Content");
            return Ok(dict);
        }

        /// <summary>
        /// /api/rest2/content?title=Titulo
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [Route("content")]
        [HttpGet]
        public string obtener(string title)
        {
            // para imprimir mensajes en consola
            Debug.WriteLine("titulo obtenido: " + title);
            return "Title: " + title;
        }

        /// <summary>
        /// /api/rest2/content2
        /// /api/rest2/content2?title=Titulo
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [Route("content2")]
        [HttpGet]
        public string obtener2(string title="Default")
        {
            return "Title2: " + title;
        }

        /// <summary>
        /// /api2/all/methods
        /// acepta determinados verbos y salta el path de la clase con ~/
        /// </summary>
        /// <returns></returns>
        [Route("~/api2/all/methods")]
        [AcceptVerbs("GET", "POST", "PUT", "DELETE")]
        public string all()
        {
            return "all methods";
        }
    }
}
