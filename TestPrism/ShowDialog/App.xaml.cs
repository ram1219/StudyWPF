 using Prism.Ioc;
using Prism.Unity;
using ShowDialog.Dialogs;
using ShowDialog.ViewModels;
using ShowDialog.Views;
using System.Windows;
using Unity;

namespace ShowDialog
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
			// MessageDialog 페이지를 MessagseDialogViewModel을 이용하여 오픈.
			containerRegistry.RegisterDialog<MessageDialog, MessageDialogViewModel>();
		}
	}
}
