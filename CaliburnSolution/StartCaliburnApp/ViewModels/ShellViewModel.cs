using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StartCaliburnApp.ViewModels
{
	public class ShellViewModel : PropertyChangedBase, IHaveDisplayName
	{
		string name;
		public string Name
		{
			get => name;
			set
			{
				name = value;
				// 입력받은(변경된) Name을 그대로 넣어줌
				// 안의 값은 속성으로 받는다.
				NotifyOfPropertyChange(() => Name);
				NotifyOfPropertyChange(() => CanSayHello);
			}
		}

		public bool CanSayHello
		{
			get => !string.IsNullOrEmpty(Name);
		}

		public void SayHello()
		{
			MessageBox.Show($"Hello {Name}");
		}

		public string DisplayName { get; set; }

		public ShellViewModel()
		{
			DisplayName = "Basic Caliburn App";
		}
	}
}
