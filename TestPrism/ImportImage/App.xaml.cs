using ImportImage.Views;
using Prism.Ioc;
using Prism.Unity;
using System.Windows;

namespace ImportImage
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
	}
}
