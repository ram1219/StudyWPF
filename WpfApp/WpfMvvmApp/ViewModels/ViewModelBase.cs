using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmApp.ViewModels
{
	// 값이 바뀔 경우
	public class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void RaisePropertyChanged(string propertyName)
		{
			// propertyName이 변경될 경우 시스템에 알림
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

			// 위와 같은 작업
			/* if(PropertyChanged != null)
				 PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); */

		}
	}
}
