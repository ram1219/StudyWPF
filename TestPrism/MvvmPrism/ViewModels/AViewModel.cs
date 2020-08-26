using MvvmPrism.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Windows.Navigation;

namespace MvvmPrism.ViewModels
{
	public class AViewModel : BindableBase
	{
		// 대리자 생성
		public DelegateCommand UpdateCommand { get; set; }

		private IEventAggregator _eventAggregator;
		public AViewModel(IEventAggregator eventAggregator)
		{
			_eventAggregator = eventAggregator;

			UpdateCommand = new DelegateCommand(Execute, CanExecute);
			UpdateCommand.ObservesProperty(() => FirstName);
			UpdateCommand.ObservesProperty(() => LastName);
		}	

		private string _firstName;
		public string FirstName
		{
			get => _firstName;
			set { SetProperty(ref _firstName, value); }
		}

		private string _lastName;
		public string LastName
		{
			get => _lastName;
			set { SetProperty(ref _lastName, value); }
		}

		private DateTime? _lastUpdated;
		public DateTime? LastUpdated
		{
			get => _lastUpdated;
			set { SetProperty(ref _lastUpdated, value); }
		}

		private void Execute()
		{
			LastUpdated = DateTime.Now;

			_eventAggregator.GetEvent<UpdateEvent>().Publish(LastUpdated.ToString());
		}

		// 버튼 활성화
		private bool CanExecute()
		{
			return !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName);
		}

	}
}
