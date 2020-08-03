using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;

namespace SecondCaliburnApp.ViewModels
{
	public class FirstChildViewModel : Screen
	{
		public void FirstClicked()
		{
			MessageBox.Show("Hello World!!");
		}
	}
}
