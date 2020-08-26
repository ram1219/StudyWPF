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
	public class AViewModel : BindableBase
	{
		private string _message;
		public string Message
		{
			get => _message;
			set { SetProperty(ref _message, value); }
		}

		private string _messageReceive;
		public string MessageReceive
		{
			get => _messageReceive;
			set { SetProperty(ref _messageReceive, value); }
		}

		public DelegateCommand ShowDialogCommand { get; }
		public IDialogService _dialogService { get; }

		public AViewModel(IDialogService dialogService)
		{
			ShowDialogCommand = new DelegateCommand(ShowDialog);
			_dialogService = dialogService;
		}

		private void ShowDialog()
		{
			var param = new DialogParameters();
			param.Add("message", "This is a Test Message");

			_dialogService.ShowDialog("MessageDialog",param,result=> 
			{
				// MessageDialogViewModel에서 등록한 param(Invoke)가 실행 된다.
				if(result.Result == ButtonResult.OK)
				{
					MessageReceive = result.Parameters.GetValue<string>("myParam");
				}
				else
				{
					MessageReceive = "Okay Button not Clicked";
				}
			});
		}
	}
}
