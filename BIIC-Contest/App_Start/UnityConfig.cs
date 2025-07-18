using BIIC_Contest.Services;      // Thêm using cho services
using BIIC_Contest.Services.I;  // Thêm using cho interfaces
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace BIIC_Contest
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ISubmissionService, SubmissionService>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}