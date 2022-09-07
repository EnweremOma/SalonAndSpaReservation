using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using SalonAndSpaReservation.Domain.Abstract;
using SalonAndSpaReservation.Domain.Concrete;
using System.Web.Routing;

namespace SalonAndSpaReservation.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
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
            // put bindings here
            kernel.Bind<ICustomerRepository>().To<EFCustomerRepository>();
            kernel.Bind<IAppointmentRepository>().To<EFAppointmentRepository>();
            kernel.Bind<IServiceRepository>().To<EFServiceRepository>();
            kernel.Bind<IMaterialRepository>().To<EFMaterialRepository>();
            kernel.Bind<IMaterialToServiceRepository>().To<EFMaterialToServiceRepository>();
        }
    }
}