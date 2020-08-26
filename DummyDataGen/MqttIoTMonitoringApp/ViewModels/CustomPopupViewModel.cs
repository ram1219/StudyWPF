using Caliburn.Micro;
using MqttIoTMonitoringApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqttIoTMonitoringApp.ViewModels
{
	public class CustomPopupViewModel : Conductor<object>
	{
		private string brokerIp;
		public string BrokerIp
		{
			get => brokerIp;
			set
			{
				brokerIp = value;
				NotifyOfPropertyChange(() => BrokerIp);
			}
		}

		private string topic;
		public string Topic
		{
			get => topic;
			set
			{
				topic = value;
				NotifyOfPropertyChange(() => Topic);
			}
		}

		// 생성자
		public CustomPopupViewModel(string title)
		{
			this.DisplayName = title;   // View의 TextBlock

			BrokerIp = "localhost";
			Topic = "home/device/data/";
		}

		// ACCEPT Button
		public void AcceptClose()
		{
			Commons.BROKERHOST = BrokerIp;
			Commons.PUB_TOPIC = Topic;

			TryClose(true);					// 데이터 저장 후 다이얼로그 종료
		}
	}
}
