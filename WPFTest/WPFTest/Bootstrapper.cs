using Caliburn.Micro;
using System.Windows;
using WPFTest.ViewModels;

namespace WPFTest
{
	public class Bootstrapper : BootstrapperBase
	{
		// 생성자
		public Bootstrapper()
		{
			Initialize();
		}

		// 재정의
		// ViewModel을 이용하여 View를 불러온다.
		protected override void OnStartup(object sender, StartupEventArgs e)
		{
			DisplayRootViewFor<ShellViewModel>();     // object -> ViewModel
		}
	}
}
