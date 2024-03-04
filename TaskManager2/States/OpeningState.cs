using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager2.Abstract;
using TaskManager2.Commands;
using TaskManager2.Core;

namespace TaskManager2.States {
    class OpeningState : IState {

        private TaskManager _manager;

        public OpeningState(TaskManager manager) {
            _manager = manager;
        }

        public void Render() {
            Console.WriteLine("Choose one of the followings:");
            Console.WriteLine("[exit] - Close Program");
            Console.WriteLine("[new] - Create New TaskList");
            Console.WriteLine("[open] - Open an Existing TaskList");
            Console.WriteLine("[delete] - Delete an Existing TaskList");
        }
        public ICommand GetCommand() {
            var command = Console.ReadLine();
            if (command == "exit") {
                return new ExitProgramCommand();
            }
            if (command == "new") {
                return new NewTaskListCommand(_manager);
            }
            if (command == "open") {
                return new SwitchStateCommand(_manager, new OpenTaskListState(_manager, this));
            }
            if (command == "delete") {
                return new SwitchStateCommand(_manager, new DeleteTaskListState(_manager, this));
            }

            return new InvalidCommand();

        }

       
    }
}
