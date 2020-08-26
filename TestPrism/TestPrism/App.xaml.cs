using Prism.Ioc;
using Prism.Unity;
using System.ComponentModel;
using System.Windows;
using TestPrism.Views;

namespace TestPrism
{
	/// <summary>
	/// App.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class App : PrismApplication
	{
		protected override Window CreateShell()
		{
			// 시작 화면 리턴
			return Container.Resolve<MainView>();
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{

		}


	}
}
