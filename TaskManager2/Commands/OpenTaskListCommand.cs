using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskManager2.Abstract;
using TaskManager2.Core;
using TaskManager2.States;
using Newtonsoft.Json;

namespace TaskManager2.Commands {
    class OpenTaskListCommand : ICommand {

        private TaskManager _manager;

        public OpenTaskListCommand(TaskManager manager) {
            _manager = manager;
        }
        public void Execute() {
            
            Console.WriteLine("Type the name");
            var file = Console.ReadLine();
            try {
                _manager.OpenTaskList(file);
                Console.WriteLine("TaskList Opened. Name: {0} ", _manager.Name);
                new SwitchStateCommand(_manager, new MainMenuState(_manager)).Execute();

            } catch (FileNotFoundException ex) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            } catch (JsonReaderException ex) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            
        }
    }
}
