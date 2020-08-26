using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationTest.ViewModels
{
	public class FamilyDetailsViewModel
	{
		public DelegateCommand<string> NavigateCommand { get; set; }

		private IRegionManager IregionManager;
		public FamilyDetailsViewModel(IRegionManager iregionManager)
		{
			IregionManager = iregionManager;
			NavigateCommand = new DelegateCommand<string>(Navigate);
		}

		private void Navigate(string uri)
		{
			IregionManager.RequestNavigate("FullContent", uri);
			
		}
	}
}
