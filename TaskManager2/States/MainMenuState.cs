using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager2.Abstract;
using TaskManager2.Commands;
using TaskManager2.Core;

namespace TaskManager2.States {
    class MainMenuState : IState {

        private TaskManager _manager;

        public MainMenuState(TaskManager manager) {
            _manager = manager;
            Console.Title = Console.Title + ": " + _manager.Name;
        }

        public ICommand GetCommand() {
            var command = Console.ReadLine();

            if (command == "close") {
                Console.WriteLine("Close command will close the TaskList without saving Data. Are you sure?");
                Console.WriteLine("[Y] - Yes");
                Console.WriteLine("[Any Key] - No");

                string choise = Console.ReadLine();
                Console.WriteLine();
                if (choise == "Y")
                    return new CloseTaskListCommand(_manager);

                return new NullCommand();
            }
            if (command == "save") {
                return new SaveTaskListCommand(_manager);            
            }
            if (command == "clear") {
                Console.Clear();
                return new NullCommand();
            }
            if (command == "saveclose") {
                new SaveTaskListCommand(_manager).Execute();
                return new CloseTaskListCommand(_manager);            
            }
            if (command == "show") {
                return new SwitchStateCommand(_manager, new ShowTasksState(_manager, this));
            }
             if (command == "new") {
                return new SwitchStateCommand(_manager, new ShowTasksState(_manager, this));
            }

            return new InvalidCommand();
        }

        public void Render() {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Task List : {0}", _manager.Name);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("[close] - Close Task List ( Without Saving Data )");
            Console.WriteLine("[save] - Save Task List");
            Console.WriteLine("[clear] - CLear Console");
            Console.WriteLine("[saveclose] - Save and Close Task List");
            Console.WriteLine("[show] - Show Summary Tasks");
            Console.WriteLine("[new] - Create New Task");
        }
    }
}
