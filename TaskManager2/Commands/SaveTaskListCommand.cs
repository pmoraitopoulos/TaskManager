using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager2.Abstract;
using TaskManager2.Core;

namespace TaskManager2.Commands {
    class SaveTaskListCommand : ICommand {

        private TaskManager _manager;

        public SaveTaskListCommand(TaskManager manager) {
            _manager = manager;
        }

        public void Execute() {
            _manager.SaveTaskList();
            Console.WriteLine("TaskList {0} has been saved succesfully. Time: {1}", _manager.Name, DateTime.Now);
        }
    }
}
