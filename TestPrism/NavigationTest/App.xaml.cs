using CommonServiceLocator;
using NavigationTest.Module;
using NavigationTest.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.ComponentModel;
using System.Windows;

namespace NavigationTest
{
	/// <summary>
	/// App.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class App : PrismApplication
	{
		protected override Window CreateShell()
		{
			return Container.Resolve<MainView>();
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
		
		}

		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
			base.ConfigureModuleCatalog(moduleCatalog);
			moduleCatalog.AddModule<MainModule>();
		}
	}
}
