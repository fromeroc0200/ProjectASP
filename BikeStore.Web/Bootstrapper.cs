using System.Web.Mvc;
using BikeStore.Data.Model;
using Microsoft.Practices.Unity;
using Unity.Mvc4;

namespace BikeStore.Web
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();
      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
            
    }
  }
}