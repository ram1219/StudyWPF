using ModuleA;
using ModuleA.Views;
using OTaYoungABang;
using OTaYoungABang.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using PrismModule.Views;
using System.Windows;

namespace PrismModule
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
			// AView -> ButtonView로 Navigation
			containerRegistry.RegisterForNavigation<ButtonView>();

			// BackButtonView -> AView로 Navigation
			containerRegistry.RegisterForNavigation<AView>();
		}

		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
			base.ConfigureModuleCatalog(moduleCatalog);
			// ModuleA의 Module 추가
			moduleCatalog.AddModule<ModuleAModule>();
			// OTaYoungABankg의 Module 추가
			moduleCatalog.AddModule<OTaYoungABangModule>();
		}
	}
}
