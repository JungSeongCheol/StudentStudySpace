using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfMvvmApp
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> execute;
        readonly Predicate<T> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute = null) // 
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute)); // ??(널값체크? + 삼항연산자, 이식에서는 널값이면 throw new ~~가 나오고
            // 아니면 execute가 집어넣어진다.
            this.canExecute = canExecute;
        }

        public RelayCommand(Action<T> execute) : this(execute, null) { }

        public bool CanExecute(object parameter) => canExecute?.Invoke((T)parameter) ?? true; // Invoke는 접근하고자 하는 윈도우에서 파생된 쓰레드가 아닌
        //다른 쓰레드에서 이 윈도우에 접근을 시도할 때 에러를 발생시키는데, 이 에러를 없애고자 사용합니다. 그리고 (T)의 뜻!!!! cast연산자와 동일함.

        public void Execute(object parameter) => execute((T)parameter);
    }
}
