using LeftModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeftModule
{
    public class ModuleLoader : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var region = containerProvider.Resolve<IRegionManager>();
            region.RegisterViewWithRegion("LeftRegion", typeof(MessageView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
