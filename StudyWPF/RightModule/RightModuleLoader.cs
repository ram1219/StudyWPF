using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using RightModule.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace RightModule
{
	public class RightModuleLoader : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			var region = containerProvider.Resolve<IRegionManager>();
			region.RegisterViewWithRegion("RightRegion", typeof(MessageListView));
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			
		}
	}
}
