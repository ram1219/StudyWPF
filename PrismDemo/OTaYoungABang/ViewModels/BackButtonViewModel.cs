using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace OTaYoungABang.ViewModels
{
	public class BackButtonViewModel : BindableBase
	{
		public DelegateCommand<string> NavigateCommand { get; set; }

		private IRegionManager _regionManager;
		public BackButtonViewModel(IRegionManager regionManager)
		{
			_regionManager = regionManager;
			NavigateCommand = new DelegateCommand<string>(Navigate);
		}

		private void Navigate(string uri)
		{
			// AView를 불러오고
			_regionManager.RequestNavigate("ContentRegion", uri);

			// 나머지 Region 비우기
			_regionManager.Regions["FirstRegion"].RemoveAll();
			_regionManager.Regions["SecondRegion"].RemoveAll();
		}
	}
}
