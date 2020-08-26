using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using static MvvmPrism.App;

namespace MvvmPrism.ViewModels
{
	public class MainViewModel : BindableBase
	{
		// IRegionManager -> Region 등록 및 관리
		private readonly IRegionManager _regionManager;

		// Navigate를 실행할 대리자 생성
		public DelegateCommand<string> NavigateCommand { 
			get; 
			private set; 
		}

		public MainViewModel(IRegionManager regionManager)
		{
			_regionManager = regionManager;
			NavigateCommand = new DelegateCommand<string>(Navigate);
		}

		private void Navigate(string uri)
		{
			_regionManager.RequestNavigate("ContentRegion", uri);
		}
	}
}
