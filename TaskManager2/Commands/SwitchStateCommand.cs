using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager2.Abstract;
using TaskManager2.Core;

namespace TaskManager2.Commands {
    class SwitchStateCommand : ICommand {

        private TaskManager _manager;
        private IState _state;

        public SwitchStateCommand(TaskManager manager, IState state) {
            _manager = manager;
            _state = state;
        }

        public void Execute() {
            Console.Clear();
            _manager.SwitchState(_state);
        }
    }
}
