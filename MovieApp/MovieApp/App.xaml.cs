using MovieApp.Modules;
using MovieApp.ViewModels;
using MovieApp.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Unity;
using System.Windows;

namespace MovieApp
{
	/// <summary>
	/// App.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class App : PrismApplication
	{
		protected override Window CreateShell()
		{
			return Container.Resolve<ShellView>();
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			
		}

		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
			base.ConfigureModuleCatalog(moduleCatalog);
			moduleCatalog.AddModule<LoginViewModule>();
		}
	}
}
