using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.ViewModels
{
	public class AViewModel : BindableBase
	{
		private string _title = "Hello from AViewModel";

		public string Title
		{
			get => _title;
			set { SetProperty(ref _title, value); }
		}

		#region Navigation Part

		public DelegateCommand<string> NavigateCommand { get; set; }

		private IRegionManager _regionManager;
		public AViewModel(IRegionManager regionManager)
		{
			_regionManager = regionManager;
			NavigateCommand = new DelegateCommand<string>(Navigate);
		}

		private void Navigate(string uri)
		{
			// CommandParam 설정 되어있는 창을 MainView의 FirstRegion에 띄운다
			_regionManager.RequestNavigate("FirstRegion", uri);

			// MainView의 ContentRegion 부분을 지운다
			_regionManager.Regions["ContentRegion"].RemoveAll();
		}

		#endregion
	}
}
