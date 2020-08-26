using Caliburn.Micro;
using MqttIoTMonitoringApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MqttIoTMonitoringApp.ViewModels
{
	public class MainViewModel : Conductor<object>
	{
		// 생성자
		public MainViewModel()
		{
			// MainView의 Title
			DisplayName = "Mqtt Monitoring App - v0.9";
		}

		protected override void OnDeactivate(bool close) //닫힘버튼 눌럿을때
		{
			if (Commons.BROKERCLIENT.IsConnected)
			{
				Commons.BROKERCLIENT.Disconnect(); //연결 끊어줌
				Commons.BROKERCLIENT = null;
			}
			Environment.Exit(0); //완전 종료
		}

		public void PopInfoDialog()
		{
			TaskStart();
		}

		// CustomPopup 다이얼로그를 띄움
		private void TaskStart()
		{
			var wManager = new WindowManager();
			var result = wManager.ShowDialog(new CustomPopupViewModel("New Broker"));	// 다이얼로그가 실행 완료 된 후 return true

			// 다이얼로그 실행 완료 된 경우 (Accept 버튼으로 종료)
			if (result == true) 
			{
				//MessageBox.Show("Start Subscribe!!!");
				ActivateItem(new DataBaseViewModel());
			}
		}

		// DataBase MenuItem
		public void LoadDataBaseView()
		{
			if((Commons.BROKERCLIENT != null))
			{
				ActivateItem(new DataBaseViewModel());	// MainView에 DataBaseView Binding
			}
			else
			{
				// ErrorPopupView를 생성. -> Main에서 WindowManager로 ShowDialog 하여 팝업창 실행
				var wManager = new WindowManager();
				wManager.ShowDialog(new ErrorPopupViewModel("Error|MQTT가 실행되지 않았습니다."));
			}
		}

		// RealTime MenuItem
		public void LoadRealTimeView()
		{
			ActivateItem(new RealTimeViewModel());
		}

		// History MenuItem
		public void LoadHistoryView()
		{
			ActivateItem(new HistoryViewModel());
		}

		// Menu의 Exit
		public void ExitProgram() { Environment.Exit(0); }

		// ToolBar의 Exit
		public void ExitApp() { ExitProgram(); }
	}
}
