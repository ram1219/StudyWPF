using Caliburn.Micro;
using SecondCaliburnApp.ViewModels;
using SecondCaliburnApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SecondCaliburnApp
{
	public class bootstrapper : BootstrapperBase
	{
		// 생성자
		public bootstrapper()
		{
			Initialize();
		}

		// 재정의
		protected override void OnStartup(object sender, StartupEventArgs e)
		{
			DisplayRootViewFor<ShellViewModel>();     // object -> ViewModel
		}
	}
}
