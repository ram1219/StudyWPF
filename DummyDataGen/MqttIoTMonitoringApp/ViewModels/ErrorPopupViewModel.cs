using Caliburn.Micro;
using MqttIoTMonitoringApp.Helpers;

namespace MqttIoTMonitoringApp.ViewModels
{
	public class ErrorPopupViewModel : Conductor<object>
	{
		private string errorMessage;
		public string ErrorMessage
		{
			get => errorMessage;
			set
			{
				errorMessage = value;
				NotifyOfPropertyChange(() => ErrorMessage);
			}
		}

		public void ConfirmClose()
		{
			TryClose(true);
		}

		public ErrorPopupViewModel(string param)
		{
			var tmp = param.Split('|');
			DisplayName = tmp[0];
			ErrorMessage = tmp[1];
		}
	}
}
