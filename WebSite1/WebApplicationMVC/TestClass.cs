using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebApplicationMVC
{
    public class TestClass
    {
        public async Task<string> DoLongTask()
        {
            string res = await DoIt();
            Console.WriteLine("xxx");
            return res;
        }

        private Task<string> DoIt()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(1000);
                return "";
            });
        }

        public static async Task<string> Download()
        {
            using (HttpClient client = new HttpClient())
            {
                string res = await client.GetStringAsync("http://www.microsoft.it").ConfigureAwait(false);
                //se devo fare altre cose ad esempio scrivere un file deve usare configure await false

                return res;
            }
        }
    }
}