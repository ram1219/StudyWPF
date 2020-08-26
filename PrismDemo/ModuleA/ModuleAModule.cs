using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ModuleA
{
	public class ModuleAModule : IModule
	{
		private IRegionManager _regionManager;
		public ModuleAModule(IRegionManager regionManager)
		{
			_regionManager = regionManager;
		}

		public void OnInitialized(IContainerProvider containerProvider)
		{
			_regionManager.RegisterViewWithRegion("ContentRegion", typeof(AView));

			//IRegion region = _regionManager.Regions["ContentRegion"];

			//var view1 = containerProvider.Resolve<AView>();
			//region.Add(view1);

			//// View의 내용을 바꾸고 싶을 때(View Injection)
			//var view2 = containerProvider.Resolve<AView>();
			//view2.Content = new TextBlock()
			//{
			//	Text = "Hello from View 2",
			//	HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
			//	VerticalAlignment = System.Windows.VerticalAlignment.Center
			//};
			  
			//region.Add(view2);
			//region.Activate(view2);     // view1이 아닌 view2가 실행된다.
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			
		}
	}
}
