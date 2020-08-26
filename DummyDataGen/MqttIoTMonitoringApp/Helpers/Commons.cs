using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using uPLibrary.Networking.M2Mqtt;

namespace MqttIoTMonitoringApp.Helpers
{
	public class Commons
	{
		public static string BROKERHOST { get; set; }

		public static string PUB_TOPIC { get; set; }		// home/device/data

		public static MqttClient BROKERCLIENT { get; set; }

		public static string CONNSTRING { get; set; }		// DB 연결 문자열

		public static bool ISCONNECT { get; set; }			
	}

	// 비어 있는지 확인
	public class NotEmptyValidationRule : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			// value가 null 일 경우 "" 를 출력하고 true일 경우 Field is require, false일 경우 ValidResult.
			return string.IsNullOrWhiteSpace((value ?? "").ToString())
				? new ValidationResult(false, "Field is required.") : ValidationResult.ValidResult;
		}
	}
}
