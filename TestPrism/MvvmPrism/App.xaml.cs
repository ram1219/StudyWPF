using Prism.Unity;
using System.Windows;
using MvvmPrism.Views;
using Prism.Ioc;

namespace MvvmPrism
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
			containerRegistry.RegisterForNavigation<AView>();
			containerRegistry.RegisterForNavigation<BView>();
		}

		public interface IPersonService
		{

		}

		public class PersonService : IPersonService
		{

		}
	}
}
