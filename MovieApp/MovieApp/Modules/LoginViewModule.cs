using MovieApp.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace MovieApp.Modules
{
	public class LoginViewModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			var region = containerProvider.Resolve<IRegionManager>();
			region.RegisterViewWithRegion("LoginRegion", typeof(LoginView));
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			
		}
	}
}
