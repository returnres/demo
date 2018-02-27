using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebApplicationMVC
{
    public class ServiceA : IService
    {
        private IServiceB _serviceB;
        public ServiceA(IServiceB serviceB)
        {
            this._serviceB = serviceB;
        }
        public void DoSomething()
        {
            Debug.WriteLine("DoSomething");
        }
    }
}