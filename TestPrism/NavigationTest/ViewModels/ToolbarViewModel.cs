using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NavigationTest.ViewModels
{
	public class ToolbarViewModel
	{
		private IRegionManager IregionManager;
		public ToolbarViewModel(IRegionManager iregionManager)
		{
			IregionManager = iregionManager;
			NavigateCommand = new DelegateCommand<string>(Navigate);
		}

		public DelegateCommand<string> NavigateCommand { get; set; }


		private void Navigate(string uri)
		{
			IregionManager.RequestNavigate("MainContent", uri);
		}
	}
}
