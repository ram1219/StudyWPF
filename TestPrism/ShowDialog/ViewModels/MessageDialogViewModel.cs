using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowDialog.ViewModels
{
	public class MessageDialogViewModel : BindableBase, IDialogAware
	{
		// TextBlock의 Text내용 (Binding)
		private string _message;
		public string Message
		{
			get => _message;
			set { SetProperty(ref _message, value); }
		}

		// OK 버튼 클릭 시 발생하는 CloseDialogCommand를 Delegate로 생성
		public DelegateCommand CloseDialogCommand { get; }

		// Constructor(생성자)
		public MessageDialogViewModel()
		{
			// CloseDialogCommand 이벤트가 발생하면 대리자(Delegate)는 CloseDialog 함수를 실행한다.
			CloseDialogCommand = new DelegateCommand(CloseDialog);
		}

		private void CloseDialog()
		{
			var result = ButtonResult.OK;

			var param = new DialogParameters();
			param.Add("myParam", "The Dialog was closed bu User");

			// RequesClose가 되면(다이얼로그 창 Close) Ivoke 안 실행
			// Ivoke 함수 -> 이전 실행이 종료 된 이후 실행
			RequestClose?.Invoke(new DialogResult(result, param));
		}

		#region IDialogAware Interface

		public event Action<IDialogResult> RequestClose;
		public string Title => "My Message Dialog";

		public bool CanCloseDialog()
		{
			return true;
		}

		public void OnDialogClosed()
		{
			throw new NotImplementedException();
		}

		public void OnDialogOpened(IDialogParameters parameters)
		{
			Message = parameters.GetValue<string>("message");
		}
		#endregion
	}
}
