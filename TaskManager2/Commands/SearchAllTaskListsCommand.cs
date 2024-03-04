using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager2.Abstract;
using TaskManager2.Core;

namespace TaskManager2.Commands {
    class SearchAllTaskListsCommand : ICommand {

        private TaskManager _manager;
        
        public SearchAllTaskListsCommand(TaskManager manager) {
            _manager = manager;
        }
        public void Execute() {
            string[] files = _manager.SearchAllTaskLists();

            foreach(string file in files) {
                Console.WriteLine("["+file+"]");
            }
        }
    }
}
