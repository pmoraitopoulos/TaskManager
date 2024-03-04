using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskManager2.Abstract;
using TaskManager2.Core;
using TaskManager2.States;
using TaskManager2.Storage;

namespace TaskManager2.Commands {
    class NewTaskListCommand : ICommand {

        private TaskManager _manager;

        public NewTaskListCommand(TaskManager manager) {
            this._manager = manager;
        }

        public void Execute() {
            
            if (_manager.IsTaskListClosed()) {
                Console.WriteLine("Give a Name.");
                string name = Console.ReadLine();
                try { 
                    _manager.NewTaskList(name);
                    Console.WriteLine("New TaskList Created. Name: {0} ", _manager.Name);
                    (new SwitchStateCommand(_manager, new MainMenuState(_manager))).Execute() ;

                } catch(FileExistsException ex) {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Message: {0} - Time: {1}", ex.Message, ex.Timestamp);
                    Console.ForegroundColor = ConsoleColor.White;
                   
                }

            } else {
                Console.WriteLine("Save and Close the Current TaskList ({0}) so you start a new one.", _manager.Name);
            }
           
        }
    }
}
