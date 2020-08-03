using Caliburn.Micro;
using ControlzEx.Standard;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using WPFTest.Helpers;
using WPFTest.Models;
using WPFTest.Views;
using LiveCharts.Wpf;
using LiveCharts;
using System.Windows.Media;

namespace WPFTest.ViewModels
{
	public class ShellViewModel : Conductor<object>
	{
		private short xCount = 200;

		// 타이머 사용
		DispatcherTimer timer = new DispatcherTimer();
        Random rand = new Random();

		public SeriesCollection PrintGraph { get; set; }

		// SensorModel에 Date값 전달
		private DateTime date;
		public DateTime Date
		{
			get => date;
			set
			{
				date = value;
				NotifyOfPropertyChange(() => Date);
			}
		}

		// SensorModel에 GetValue값 전달
		private ushort getvalue;
		public ushort GetValue
		{
			get => getvalue;
			set
			{
				getvalue = value;
				NotifyOfPropertyChange(() => GetValue);
			}
		}

		// 타이머가 초당 랜덤으로 변경되는 값
		private ushort timervalue;
		public ushort TimerValue
		{
			get => timervalue;
			set
			{
				timervalue = value;
				NotifyOfPropertyChange(() => TimerValue);
				NotifyOfPropertyChange(() => Date);
				NotifyOfPropertyChange(() => GetValue);

				NotifyOfPropertyChange(() => TxtSensorCount);
				NotifyOfPropertyChange(() => TxtPrgValue);
				NotifyOfPropertyChange(() => RtbLog);

				NotifyOfPropertyChange(() => PrintGraph);
			}
		}

		// SensorMedel과 데이터 바인딩
		public BindableCollection<SensorModel> Sensor;

		#region 생성자 영역
		public ShellViewModel()
		{
			// SensorModel과 바인딩 된 Collection 생성
			Sensor = new BindableCollection<SensorModel>();

			// 그래프 생성
			PrintGraph = new SeriesCollection
			{
				new LineSeries
				{
					Title = "PotoValue",
					Values = new ChartValues<int>(),
					Fill = Brushes.Transparent,
					Stroke = Brushes.Black,
					PointGeometrySize = 6
				}
			};
		}
		#endregion

		// 센서 모델 중 한 개
		private SensorModel selectSensor;

		// DB 연결 후 받은 값 INSERT
		private void InsertDataToDB(SensorModel data)
		{
			using (MySqlConnection conn = new MySqlConnection(Commons.STRCONNSTRING))
			{
				// DB 연결
				conn.Open();
				MySqlCommand cmd = new MySqlCommand(Commons.INSERTQUERY, conn);

				// Date값을 DB에 Insert
				MySqlParameter paramDate = new MySqlParameter("@Date", MySqlDbType.DateTime);
				paramDate.Value = data.Date;
				cmd.Parameters.Add(paramDate);

				// 랜덤값을 DB에 Insert
				MySqlParameter paramValue = new MySqlParameter("@Value", MySqlDbType.Int32);
				paramValue.Value = data.GetValue;
				cmd.Parameters.Add(paramValue);

				cmd.ExecuteNonQuery();
			}
		}

		// Start 버튼을 누른 경우
		public void BtnStart()
		{
			// 타이머 세팅
			timer.Interval = TimeSpan.FromMilliseconds(1000);	// 시간간격 설정
			timer.Tick += new EventHandler(Timer_Tick);			// 이벤트 추가
			timer.Start();                                      // 타이머 시작 설정
		}

		// 타이머동안 실행시킬 동작
		private void Timer_Tick(object sender, EventArgs e)
		{
			ushort value = (ushort)rand.Next(1, 1024);
			TimerValue = value;
			selectSensor = new SensorModel { Date = DateTime.Now, GetValue = TimerValue };
			Sensor.Add(selectSensor);
			InsertDataToDB(selectSensor);
		}

		// Stop 버튼을 누른 경우
		public void BtnStop()
		{
			timer.Stop();
		}

		// Info 버튼을 누른 경우
		public void BtnInfo()
		{
			IWindowManager btninfo = new WindowManager();
			btninfo.ShowDialog(new InfoViewModel(), null, null);
		}

		// TxtSensorCount에 들어가는 값
		public string TxtSensorCount
		{
			get
			{
				if (timer.IsEnabled)
					return (Sensor.Count + 1).ToString();
				else
					return "";
			}
		}

		// 프로그래스 바 값 출력
		public string TxtPrgValue
		{
			get
			{
				if (TimerValue != 0)
				{
					PrintGraph[0].Values.Add((int)TimerValue);
					return TimerValue.ToString();
				}
				else
					return "";
			}
		}

		// DB에 들어가는 값 출력
		StringBuilder DataLog = new StringBuilder();
		public string RtbLog
		{
			get 
			{
				if(TimerValue != 0)
				{
					string item = $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}\t{TimerValue}\n";
					DataLog.Append(item);
				}
				return DataLog.ToString();
			}
		}
		
		
	}
}
