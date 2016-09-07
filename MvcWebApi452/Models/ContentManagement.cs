using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MvcWebApi452.Models
{
    /// <summary>
    /// https://www.exceptionnotfound.net/using-async-and-await-in-asp-net-what-do-these-keywords-mean/
    /// </summary>
    public class ContentManagement
    {
        public string GetContent()
        {
            Thread.Sleep(2000);
            return "content";
        }

        public int GetCount()
        {
            Thread.Sleep(5000);
            return 4;
        }

        public string GetName()
        {
            Thread.Sleep(3000);
            return "Matthew";
        }

        public async Task<string> GetContentAsync()
        {
            await Task.Delay(2000);
            return "content";
        }

        public async Task<int> GetCountAsync()
        {
            await Task.Delay(5000);
            return 4;
        }

        public async Task<string> GetNameAsync()
        {
            await Task.Delay(3000);
            return "Matthew";
        }

        public async Task<string> GetContentAsync2()
        {
            await Task.Run(() => { Thread.Sleep(2000); });
            return "content";
        }

        public async Task<int> GetCountAsync2()
        {
            await Task.Run(() => { Thread.Sleep(5000); });
            return 4;
        }

        public async Task<string> GetNameAsync2()
        {
            await Task.Run(() => { Thread.Sleep(3000); });
            return "Matthew";
        }

        public async Task<string> normalMethodAsync()
        {
            string parametro = "Test 001";
            var rs = await Task.Run(() => { return normalMethod(parametro); });
            return rs;
        }

        public async Task<string> normalMethodAsync2()
        {
            string parametro = "Test 002";
            var rs = await Task.Run(() => normalMethod(parametro));
            return rs;
        }

        public async Task<string> normalMethodAsyncError()
        {
            string parametro = "Test 002";
            var rs = await Task.Run(() => normalMethodError(parametro));
            return rs;
        }

        public string normalMethod(string param) 
        {
            Thread.Sleep(1000);
            return "Return: " + param;
        }

        public string normalMethodError(string param, bool error = true)
        {
            Thread.Sleep(1000);
            if (error)
            {
                throw new Exception("Error desde normalMethodError");
            }
            return "Return: " + param;
        }
    }
}