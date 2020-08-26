using Prism.Commands;
using Prism.Mvvm;

namespace TestPrism.ViewModels
{
	public class MainViewModel:BindableBase
	{
		// Delegate 선언
		public DelegateCommand cmd;

		// xaml과 바인딩 되는 텍스트
		private string testText;
		public string TestText
		{
			get => testText;
			set
			{
				SetProperty(ref testText, value);
			}
		}

		// 생성자
		public MainViewModel()
		{
			// TxtChange()를 동작하는 Delegate 생성
			cmd = new DelegateCommand(TxtChange);
			// Delegate가 수행할 컨트롤 이벤트 전달
			TxtChangeCommand = cmd;
			// 텍스트 초기화
			TestText = "Hello";
		}

		// Delegate
		private DelegateCommand txtchangecommand;
		public DelegateCommand TxtChangeCommand
		{
			get => txtchangecommand;
			set
			{
				SetProperty(ref txtchangecommand, value);
			}
		}

		// 컨트롤 이벤트
		private void TxtChange()
		{
			if (TestText.Equals("Hello"))
				TestText = "World";
			else TestText = "Hello";
		}
	}
}
