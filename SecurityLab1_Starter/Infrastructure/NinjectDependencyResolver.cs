using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecurityLab1_Starter.Infrastructure.Concrete;
using SecurityLab1_Starter.Infrastructure.Abstract;


namespace SecurityLab1_Starter.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        //public NinjectDependencyResolver(IKernel kernelParam)
        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<Abstract.IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}