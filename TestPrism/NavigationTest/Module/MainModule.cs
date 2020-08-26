using NavigationTest.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace NavigationTest.Module
{
	public class MainModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			var region = containerProvider.Resolve<IRegionManager>();
			region.RegisterViewWithRegion("MainContent", typeof(FamilyDetails));
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<ToolBar>();
			containerRegistry.RegisterForNavigation<Logger>();
			containerRegistry.RegisterForNavigation<FamilyDetails>();
		}
	}
}
