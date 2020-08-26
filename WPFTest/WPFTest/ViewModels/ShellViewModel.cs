using Caliburn.Micro;
using MySql.Data.MySqlClient;
using System;
using System.Text;
using System.Windows.Threading;
using WPFTest.Helpers;
using WPFTest.Models;
using LiveCharts.Wpf;
using LiveCharts;
using System.Windows.Media;
using LiveCharts.Wpf.Charts.Base;
using System.IO.Ports;
using WPFTest.Views;

namespace WPFTest.ViewModels
{
	public class ShellViewModel : Conductor<object>
	{
		DispatcherTimer timer = new DispatcherTimer();                  // 타이머
		Random rand = new Random();                                     // 랜덤값
		SerialPort serial;                                              // 아두이노 시리얼

		public BindableCollection<SensorModel> Sensor;                  // SensorMedel과 데이터 바인딩
		private SensorModel selectSensor;                               // 센서 모델 중 한 개

		public BindableCollection<string> CboSerialPort { get; set; }   // 콤보박스 바인딩

		public SeriesCollection PrintGraph { get; set; }                // 그래프

		#region Constructor Part
		public ShellViewModel()
		{
			// SensorModel을 Binding이 가능한 Collection 으로 생성
			// 여러개의 Sensor모델을 저장하는 리스트와 같은 역할
			Sensor = new BindableCollection<SensorModel>();

			InitGraph();        // 그래프
			InitControls();     // 콤보박스
		}
		#endregion

		#region Model Part
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
		#endregion

		#region Property Part

		// 타이머가 초당 랜덤으로 변경되는 값 / 센서가 변경되는 값
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
				NotifyOfPropertyChange(() => PrgSensor);
				NotifyOfPropertyChange(() => RtbLog);
			}
		}

		// DB에 들어가는 값 출력
		StringBuilder DataLog = new StringBuilder();
		public string RtbLog
		{
			get
			{
				string item = "";
				if (TimerValue != 0)
				{
					item = $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}\t{TimerValue}\n";
				}

				DataLog.Append(item);
				return DataLog.ToString();
			}
		}

		// 콤보박스 아이템 선택(xaml 바인딩)
		private string selectedcboitem;
		public string Selectedcboitem
		{
			get => selectedcboitem;
			set
			{
				selectedcboitem = value;

				NotifyOfPropertyChange(() => Selectedcboitem);
				NotifyOfPropertyChange(() => CanBtnConnect);
				NotifyOfPropertyChange(() => PrintPortNumber);
			}
		}

		// 시뮬레이션 모드 설정
		private bool isSimulation;
		public bool IsSimulation
		{
			get => isSimulation;
			set
			{
				isSimulation = value;

				NotifyOfPropertyChange(() => IsSimulation);
				NotifyOfPropertyChange(() => PrgSensor);
				NotifyOfPropertyChange(() => TxtSensorTime);
				NotifyOfPropertyChange(() => TxtSensorCount);
			}
		}

		// 센서 모드 설정
		private bool isSensorMode;
		public bool IsSensorMode
		{
			get => isSensorMode;
			set
			{
				isSensorMode = value;

				NotifyOfPropertyChange(() => IsSensorMode);
				NotifyOfPropertyChange(() => PrgSensor);
				NotifyOfPropertyChange(() => TxtSensorTime);
				NotifyOfPropertyChange(() => TxtSensorCount);

				NotifyOfPropertyChange(() => CanBtnDisconnect);
			}
		}

		// 카운트 되는 갯수 출력
		public string TxtSensorCount
		{
			get
			{
				if (IsSimulation)
					return (Sensor.Count + 1).ToString();
				else if (IsSensorMode)
					return "Sensor Mode";
				else
					return "";
			}
		}

		// 프로그래스 바
		public ushort PrgSensor
		{
			get => TimerValue;
		}

		// 연결시간 출력
		public string TxtSensorTime
		{
			get
			{
				if (IsSimulation)
					return "Simulation Mode";
				else if (IsSensorMode)
					return $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}";
				else
					return "";
			}
		}

		// 포트 넘버 출력
		public string PrintPortNumber
		{
			get
			{
				if (string.IsNullOrEmpty(Selectedcboitem))
					return "Port";
				else
					return Selectedcboitem;
			}
		}

		// 콤보박스가 선택되지 않으면 Connect 버튼 비활성화
		public bool CanBtnConnect
		{
			get => !(string.IsNullOrEmpty(Selectedcboitem));
		}

		// DisConnect 버튼 비활성화
		public bool CanBtnDisconnect
		{
			get => IsSensorMode;
		}
		#endregion

		#region Method Part

		// 그래프 생성
		private void InitGraph()
		{
			PrintGraph = new SeriesCollection
			{
				new LineSeries
				{
					Title = "PhotoValue",
					Values = new ChartValues<int>(),
					Fill = Brushes.Transparent,
					Stroke = Brushes.Black,
					PointGeometrySize = 5
				}
			};
		}

		// 콤보박스 초기 설정
		private void InitControls()
		{
			IsSimulation = false;

			CboSerialPort = new BindableCollection<string>();
			foreach (var item in SerialPort.GetPortNames())
			{
				CboSerialPort.Add(item);
			}
		}

		// 타이머동안 실행시킬 동작
		private void Timer_Tick(object sender, EventArgs e)
		{
			ushort value = (ushort)rand.Next(1, 1024);
			UsingValue(value);
		}

		// 변경된 값을 사용 -> DB에 값 전달, 그래프에 값 전달
		public void UsingValue(ushort value)
		{
			TimerValue = value;

			// PrintGraph(SeriesCollection) -> LineSeries -> Values = ChartValues 
			PrintGraph[0].Values.Add((int)value);

			selectSensor = new SensorModel { Date = DateTime.Now, GetValue = value };
			Sensor.Add(selectSensor);
			InsertDataToDB(selectSensor);
		}

		// DB 연결 후 받은 값 INSERT
		private void InsertDataToDB(SensorModel data)
		{
			using (MySqlConnection conn = new MySqlConnection(Commons.STRCONNSTRING))
			{
				// DB 연결
				conn.Open();
				MySqlCommand cmd = new MySqlCommand(Commons.INSERTQUERY, conn);

				// 날짜값을 DB에 Insert
				MySqlParameter paramDate = new MySqlParameter("@Date", MySqlDbType.DateTime);
				paramDate.Value = data.Date;
				cmd.Parameters.Add(paramDate);

				// 프로그래스바값을 DB에 Insert
				MySqlParameter paramValue = new MySqlParameter("@Value", MySqlDbType.Int32);
				paramValue.Value = data.GetValue;
				cmd.Parameters.Add(paramValue);

				cmd.ExecuteNonQuery();
			}
		}

		// 시리얼에서 값 읽어오기
		private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			string sVal = serial.ReadLine();
			UsingValue(ushort.Parse(sVal));
		}

		// Start 메뉴를 누른 경우
		public void BtnStart()
		{
			IsSimulation = true;

			// 타이머 세팅
			timer.Interval = TimeSpan.FromMilliseconds(1000);   // 시간간격 설정
			timer.Tick += new EventHandler(Timer_Tick);         // 이벤트 추가
			timer.Start();                                      // 타이머 시작 설정

			if (serial != null)
				BtnDisconnect();
		}

		// Stop 메뉴를 누른 경우
		public void BtnStop()
		{
			timer.Stop();
			IsSimulation = false;
		}

		// 시리얼 통신 연결
		public void BtnConnect()
		{
			if (IsSimulation)
				BtnStop();

			IsSensorMode = true;

			serial = new SerialPort(Selectedcboitem, 115200);
			serial.DataReceived += Serial_DataReceived;
			serial.Open();
		}

		// 시리얼 통신 종료
		public void BtnDisconnect()
		{
			if (!IsSimulation)
			{
				// 초기화 
				DataLog.Clear();
				PrintGraph.Clear();
				TimerValue = 0;
			}

			serial.Close();
			IsSensorMode = false;
		}

		// Info 버튼을 누른 경우
		public void BtnInfo()
		{
			IWindowManager btninfo = new WindowManager();
			btninfo.ShowDialog(new InfoViewModel(), null, null);
		}
	}
	#endregion


}
