﻿using Caliburn.Micro;
using StartCaliburnApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StartCaliburnApp
{
	public class Bootstrapper : BootstrapperBase
	{
		// 생성자
		public Bootstrapper()
		{
			Initialize();
		}

		// 재정의
		protected override void OnStartup(object sender, StartupEventArgs e)
		{
			DisplayRootViewFor<ButtonsViewModel>();		// object -> ViewModel
		}
	}
}
