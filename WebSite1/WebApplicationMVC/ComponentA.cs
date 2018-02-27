using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebApplicationMVC
{
    public class ComponentA : IService
    {
        private IServiceB _serviceB;
        public ComponentA(IServiceB serviceB)
        {
            this._serviceB = serviceB;
        }
        public void DoSomething()
        {
            Debug.WriteLine("DoSomething");
        }
    }
}