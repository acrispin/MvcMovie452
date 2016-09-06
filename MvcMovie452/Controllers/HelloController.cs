using System.Web;
using System.Web.Mvc;

namespace MvcMovie452.Controllers
{
    public class HelloController : Controller
    {
        // 
        // GET: /Hello/ 
        public ActionResult Index()
        {
            return View();
        }

        // 
        // GET: /Hello/Welcome/ 
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }

        // GET: /Hello/Welcome1?name=Anton&numtimes=10
        public string Welcome1(string name, int numTimes = 1)
        {
            return HttpUtility.HtmlEncode("Hello " + name + ", NumTimes is: " + numTimes);
        }

        // GET: /Hello/Welcome2?name=Anton&numtimes=10
        public ActionResult Welcome2(string name, int numTimes = 1)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;
            return View("Welcome");
        }

        // GET: /Hello/Welcome3/25?name=Anton
        //      /Hello/Welcome3/25/?name=Anton
        //      /Hello/Welcome3?name=Anton
        public string Welcome3(string name, int id = 1)
        {
            return HttpUtility.HtmlEncode("Hello " + name + ", ID: " + id);
        }

        // GET: /Hello/Welcome4/Anton/23
        public string Welcome4(string nom, int id = 1)
        {
            return HttpUtility.HtmlEncode("Hello " + nom + ", ID: " + id);
        }
    }
}