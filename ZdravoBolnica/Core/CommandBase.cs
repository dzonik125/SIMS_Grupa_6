﻿using System;
using System.Windows.Input;

namespace SIMS.Core
{
    public abstract class CommandBase:ICommand
    {
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);

        public event EventHandler CanExecuteChanged;

        protected void OnCanExecutedChanged()
        {
            CanExecuteChanged?.Invoke(this,new EventArgs());
        }
    }
}