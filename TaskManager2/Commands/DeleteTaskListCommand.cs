using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskManager2.Abstract;
using TaskManager2.Core;
using TaskManager2.States;

namespace TaskManager2.Commands {
    class DeleteTaskListCommand : ICommand {

        private TaskManager _manager;

        public DeleteTaskListCommand(TaskManager manager) {
            _manager = manager;
        }
        public void Execute() {

            Console.WriteLine("Type the name");
            var file = Console.ReadLine();
            try {
                _manager.DeleteTaskList(file);
                Console.WriteLine("TaskList Deleted. Name: {0} ", _manager.Name);
                new SwitchStateCommand(_manager, new OpeningState(_manager)).Execute();

            } catch (FileNotFoundException ex) {
                Console.WriteLine("Message: {0}", ex.Message);
            }

        }
    }
}
