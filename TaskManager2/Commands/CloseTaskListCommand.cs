using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskManager2.Abstract;
using TaskManager2.Core;
using TaskManager2.States;
using TaskManager2.Storage;

namespace TaskManager2.Commands {
    class CloseTaskListCommand : ICommand {

        private TaskManager _manager;

        public CloseTaskListCommand(TaskManager manager) {
            _manager = manager;
        }
        public void Execute() {
            if (!_manager.IsTaskListClosed()) {
                Console.WriteLine("Closing TaskList {0}...", _manager.Name);
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                _manager.CloseTaskList();
                new SwitchStateCommand(_manager, new OpeningState(_manager)).Execute();

            } else {
                Console.WriteLine("There is no open TaskList.");

            }
        }
    }
}
