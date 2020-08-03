using System;
using System.Windows.Input;

namespace WpfMvvmApp.ViewModels
{
	// 이벤트가 발생한 경우
	public class RelayCommand<T> : ICommand
	{
		// ICommand의 인터페이스 구현

		readonly Action<T> execute;			// Action -> void타입, 실행
		readonly Predicate<T> canExecute;   // Predicate -> bool타입, 실행 여부 true/false를 반환함


		public event EventHandler CanExecuteChanged
		{
			add => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}

		// 이벤트가 발생한 경우 실행이 가능한지 여부 (false일 경우 이벤트 비활성화, true일 경우 활성화)
		public bool CanExecute(object parameter) => canExecute?.Invoke((T)parameter) ?? true;
		// 이벤트가 발생했을 실행하는 동작
		public void Execute(object parameter) => execute((T)parameter);

		// 생성자
		public RelayCommand(Action<T> execute, Predicate<T> canExecute = null)
		{
			// excute가 null일 경우 throw new ~ 실행
			this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
			this.canExecute = canExecute;
		}

		// 위의 생성자를 상속받는 다른 생성자.
		// 입력받는 값이 있으면 아무런 동작도 하지 않는다.
		public RelayCommand(Action<T> execute) : this(execute, null) { }
	}
}
