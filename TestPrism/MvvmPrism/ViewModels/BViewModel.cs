using MvvmPrism.Events;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Markup;

namespace MvvmPrism.ViewModels
{
	public class BViewModel : BindableBase
	{
		private string _message = "ViewB";
		public string Message
		{
			get => _message;
			set { SetProperty(ref _message, value); }
		}

		public BViewModel(IEventAggregator eventAggregator)
		{
			eventAggregator.GetEvent<UpdateEvent>().Subscribe(Updated);
		}

		private void Updated(string obj)
		{
			Message = obj;
		}
	}
}
