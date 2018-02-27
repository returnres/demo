using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationMVC
{
    public class ServiceB : IServiceB
    {
        private string _conn;
        public ServiceB(string conn)
        {
            this._conn = conn;
        }

        public void DoSomething()
        {
            throw new NotImplementedException();
        }
    }


    public interface IServiceB
    {
        void DoSomething();
    }
}