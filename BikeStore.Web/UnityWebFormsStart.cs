using System.Web;
using BikeStore.Service;
using Microsoft.Practices.Unity;
using Unity.WebForms;


namespace BikeStore.Web
{
    
    public static class UnityWebFormsStart
    {
       
        public static void PostStart()
        {
            IUnityContainer container = new UnityContainer();
            HttpContext.Current.Application.SetContainer(container);

            RegisterDependencies(container);
        }

        /// <summary>
        ///		Registers dependencies in the supplied container.
        /// </summary>
        /// <param name="container">Instance of the container to populate.</param>
        public static void RegisterDependencies(IUnityContainer container)
        {
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            // TODO: Add any dependencies needed here
        }
    }
}