using Prism.Events;
using Prism.Mvvm;
using PrismApp.Core;
using System;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace RightModule.ViewModels
{
	public class MessageListViewModel : BindableBase
	{
		// ObservableCollection -> 아이템의 상태가 변할 경우 알려준다.(추가, 삭제, 변경)
		private ObservableCollection<string> _messages;
		public ObservableCollection<string> Messages
		{
			get => _messages;
			set => SetProperty(ref _messages, value);
		}

		private IEventAggregator _ea;
		public MessageListViewModel(IEventAggregator ea)
		{
			_ea = ea;
			Messages = new ObservableCollection<string>();  // 초기화
			_ea.GetEvent<MessageSentEvent>().Subscribe(MessageReceived, ThreadOption.PublisherThread, false,
				(filter)=>filter.Contains("prism"));		// "prism" 이 들어간 문자열만 받는다
		}

		private void MessageReceived(string message)
		{
			Messages.Add(message);
		}
	}
}
