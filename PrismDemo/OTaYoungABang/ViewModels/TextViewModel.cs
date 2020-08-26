using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTaYoungABang.ViewModels
{
	public class TextViewModel : BindableBase
	{
		public DelegateCommand<string> NavigateCommand { get; set; }

		private IRegionManager _regionManager;
		public TextViewModel(IRegionManager regionManager)
		{
			_regionManager = regionManager;
			NavigateCommand = new DelegateCommand<string>(Navigate);
		}

		private void Navigate(string uri)
		{ 
			_regionManager.RequestNavigate("FirstRegion", uri);
		}
	}
}
