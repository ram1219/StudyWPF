using OTaYoungABang.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace OTaYoungABang
{
	public class OTaYoungABangModule : IModule
	{
		private IRegionManager _regionManager;
		public OTaYoungABangModule(IRegionManager regionManager)
		{
			_regionManager = regionManager;
		}

		public void OnInitialized(IContainerProvider containerProvider)
		{
			//_regionManager.RegisterViewWithRegion("FirstRegion", typeof(ButtonView));
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<TextView>();
			containerRegistry.RegisterForNavigation<ButtonView>();
			containerRegistry.RegisterForNavigation<BackButtonView>();
		}
	}
}
