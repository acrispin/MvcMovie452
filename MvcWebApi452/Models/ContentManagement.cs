﻿using System;
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
    }
}