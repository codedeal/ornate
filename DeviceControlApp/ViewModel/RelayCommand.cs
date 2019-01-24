﻿using System;
using System.Windows.Input;

namespace DeviceControlApp.ViewModel
{
    public class RelayCommand:ICommand
    {
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;
       
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

             _execute = execute;
            _canExecute = canExecute;
          
        }

        public RelayCommand(Action<object>exeute):this(exeute,null)
        {
                
        }

        public RelayCommand(Action execute):this((obj) => { execute.Invoke(); }, null)
        {

        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }
    }
}