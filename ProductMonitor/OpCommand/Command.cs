using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProductMonitor.OpCommand
{
    public class Command : ICommand
    {
        /// <summary>
        /// 定義委託
        /// </summary>
        private Action _action;

        /// <summary>
        /// 構造函數 接收方法
        /// </summary>
        /// <param name="action"></param>
        public Command(Action action)
        {
            this._action = action;
        }


        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// 是否可以執行
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>


        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (_action != null)
            {
                _action();
            }
        }
    }
}
