using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMvvmApp.Models;

namespace WpfMvvmApp.ViewModels
{
	public class ShellViewModel : ViewModelBase
	{
		#region 멤버변수/속성영역
		// ViewModel.xaml 파일에서 받는 값
		string inLastName;
		string inFirstName;
		string inEmail;
		DateTime? inDate;       // null 값을 받을 수도 있으므로 ? 사용

		// ViewModel.xaml 파일에서 출력 값
		string outLastName;
		string outFirstName;
		string outEmail;
		string outDate;			// date를 출력할 때는 문자열로 출력을 한다.
		string outAdult;
		string outBirthday;
		string outChnZodiac;
		string outCalcZodiac;

		// 상속받은 클래스의 RaisePropertyChanged를 사용하기 위한 함수 생성
		// 값이 변경될 경우 발생하는 이벤트
		public string InLastName
		{
			get => inLastName;
			set
			{
				inLastName = value;
				RaisePropertyChanged("InLastName");
			}
		}

		public string InFirstName
		{
			get => inFirstName;
			set
			{
				inFirstName = value;
				RaisePropertyChanged("InFirstName");
			}
		}

		public string InEmail
		{
			get => inEmail;
			set
			{
				inEmail = value;
				RaisePropertyChanged("InEmail");
			}
		}

		public DateTime? InDate
		{
			get => inDate;
			set
			{
				inDate = value;
				RaisePropertyChanged("InDate");
			}
		}

		public string OutLastName
		{
			get => outLastName;
			set
			{
				outLastName = value;
				RaisePropertyChanged("OutLastName");
			}
		}

		public string OutFirstName
		{
			get => outFirstName;
			set
			{
				outFirstName = value;
				RaisePropertyChanged("OutFirstName");
			}
		}

		public string OutEmail
		{
			get => outEmail;
			set
			{
				outEmail = value;
				RaisePropertyChanged("OutEmail");
			}
		}

		public string OutDate
		{
			get => outDate;
			set
			{
				outDate = value;
				RaisePropertyChanged("OutDate");
			}
		}

		public string OutAdult
		{
			get => outAdult;
			set
			{
				outAdult = value;
				RaisePropertyChanged("OutAdult");
			}
		}

		public string OutBirthday
		{
			get => outBirthday;
			set
			{
				outBirthday = value;
				RaisePropertyChanged("OutBirthday");
			}
		}

		public string OutChnZodiac
		{
			get => outChnZodiac;
			set
			{
				outChnZodiac = value;
				RaisePropertyChanged("OutChnZodiac");
			}
		}

		public string OutCalcZodiac
		{
			get => outCalcZodiac;
			set
			{
				outCalcZodiac = value;
				RaisePropertyChanged("OutCalcZodiac");
			}
		}
		#endregion

		ICommand clickCommand;
		// RelayCommand를 통해 빈 값이 있을 경우 이벤트가 발생하지 않도록 한다.
		public ICommand ClickCommand => clickCommand ?? (clickCommand = new RelayCommand<object>(o => Click(), o=>IsClick()));

		private bool IsClick()
		{
			return (!string.IsNullOrEmpty(InLastName) && !string.IsNullOrEmpty(inFirstName) &&
				!string.IsNullOrEmpty(inEmail) && !string.IsNullOrEmpty(inDate.ToString())); 
		}

		private void Click()
		{
			try
			{
				// 날짜가 null일 경우 오늘 date를 넣는다.
				DateTime date = InDate ?? DateTime.Now;
				// Model에 생성한 class 
				Person person = new Person(InFirstName, InLastName, InEmail, date);

				OutLastName = person.LastName;
				OutFirstName = person.FirstName;
				OutDate = person.Date.ToShortDateString();
				OutEmail = person.Email;
				OutAdult = $"{person.IsAdult}";			// bool형식을 문자열로
				OutBirthday = $"{person.IsBirthDay}";   // bool형식을 문자열로
				OutChnZodiac = person.ChnZodiac;
				OutCalcZodiac = person.CalcZodiac;
			}
			catch(Exception ex)
			{
				MessageBox.Show($"Error : {ex.Message}");
			}
		}
	}
}
