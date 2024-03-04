using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager2.Abstract;
using TaskManager2.Commands;
using TaskManager2.Core;

namespace TaskManager2.States {
    class ShowTasksState : IState {

        private TaskManager _manager;
        private IState _lastState;

        public ShowTasksState(TaskManager manager, IState lastState) {
            _manager = manager;
            _lastState = lastState;
        }
        public ICommand GetCommand() {
            var command = Console.ReadLine();
            if (command == "back") {
                return new SwitchStateCommand(_manager, _lastState);
            }

            if (command == "showS") {
                string orderByKey = "";
                Order orderFormat = Order.Null;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[a] - Ascending");
                Console.WriteLine("[d] - Desceding");
                Console.WriteLine("[n] - No Order By");
                
                Console.ForegroundColor = ConsoleColor.Green;
                string command1 = Console.ReadLine();

                switch (command1) {
                    case "a":
                        orderFormat = Order.Ascending;
                        break;
                    case "d":
                        orderFormat = Order.Descending;
                        break;
                    case "n":
                        orderFormat = Order.Null;
                        break;
                    default:
                        return new InvalidCommand();
                }
                if (command1 != "n") {


                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[t] - Title");
                    Console.WriteLine("[d] - Date");
                    Console.WriteLine("[c] - Completed");
                    Console.WriteLine("[tp] - Type");

                    Console.ForegroundColor = ConsoleColor.Green;
                    command1 = Console.ReadLine();

                    switch (command1) {
                        case "t":
                            orderByKey = "Title";
                            break;
                        case "d":
                            orderByKey = "DueDate";
                            break;
                        case "c":
                            orderByKey = "IsCompleted";
                            break;
                        case "tp":
                            orderByKey = "Type";
                            break;
                        default:
                            return new InvalidCommand();
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
                return new ShowSummaryTasksCommand(_manager, orderFormat, orderByKey);
                
            }

            if (command == "showA") {

            }
            if (command == "clear") {
                Console.Clear();
                return new NullCommand();
            }

            return new InvalidCommand();
        }

        public void Render() {
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Task List : {0}", _manager.Name);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("[back] - Back");
            Console.WriteLine("[clear] - Clear");
            Console.WriteLine("[showS] - Show Summary Tasks");
            Console.WriteLine("[showA] - Show Analyticaly Tasks");
        }
    }
}
