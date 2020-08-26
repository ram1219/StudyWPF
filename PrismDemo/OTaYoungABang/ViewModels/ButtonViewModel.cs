using OTaYoungABang.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTaYoungABang.ViewModels
{
	public class ButtonViewModel : BindableBase
	{

		public DelegateCommand<string> NavigateCommand { get; set; }
		public DelegateCommand<string> ShowViewCommand { get; set; }

		private IRegionManager _regionManager;
		public ButtonViewModel(IRegionManager regionManager)
		{
			_regionManager = regionManager;
			NavigateCommand = new DelegateCommand<string>(Navigate);
			ShowViewCommand = new DelegateCommand<string>(ShowView);
		}

		private void Navigate(string uri)
		{
			_regionManager.RequestNavigate("FirstRegion", uri);
		}

		private void ShowView(string uri)
		{
			_regionManager.RequestNavigate("SecondRegion", uri);
		}
	}
}
