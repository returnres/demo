using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationMVC
{
    public class ComponentB : IServiceB
    {
        private string _conn;
        public ComponentB(string conn)
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