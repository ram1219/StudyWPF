using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BusinessLogic
{
	public class Car : Notifier
	{
		private double speed;

		private double Speed
		{
			get => speed;
			set {
				speed = value;
				OnPropertyChanged("Speed");
			}
		}

		private Color color;

		public Color Color
		{
			get
			{
				// 위 처럼 get => color 로 사용 가능
				return color;
			}
			set
			{
				color = value;
				OnPropertyChanged("Color");
			}
		}

		public Human Driver { get; set; }
	}

	public class Human
	{
		public string Name { get; set; }

		public bool HasDrivingLicense { get; set; }
	}
}
