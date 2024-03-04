using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager2.Abstract;
using TaskManager2.Core;

namespace TaskManager2.Commands {
    class ShowSummaryTasksCommand : ICommand {
        private TaskManager _manager;
        private Order _order;
        private string _orderByKey;
        

        public ShowSummaryTasksCommand(TaskManager manager, Order order, string orderByKey) {
            this._manager = manager;
            this._order = order;
            this._orderByKey = orderByKey;
        }

        public void Execute() {
            List<Dictionary<string, object>> list = _manager.GetAllTasksSummary();
            List<Dictionary<string, object>> summaryList;

            try {
                switch (_order) {
                    case Order.Ascending:
                        summaryList = list.OrderBy(d => d[_orderByKey]).ToList();
                        Print(summaryList);
                        break;
                    case Order.Descending:
                        summaryList = list.OrderByDescending(d => d[_orderByKey]).ToList();
                        Print(summaryList);
                        break;
                    case Order.Null:
                        summaryList = list;
                        Print(summaryList);
                        break;
                }

               


            } catch(KeyNotFoundException ex) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
               
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();

            }


           
        }

        private void Print(List<Dictionary<string, object>> summaryList) {
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0, -45}{1,-75}", "", "Task List Report: " + _manager.Name);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("{0, -10}{1,-35}{2,-30}{3,-15}{4, -30}", "No", "Title", "Due Date", "Completed", "Type");
            Console.ForegroundColor = ConsoleColor.White;
            int i = 1;
            foreach (var task in summaryList) {

                Console.WriteLine("{0, -10}{1,-35}{2,-30}{3,-15}{4,-30}", i, task["Title"], task["DueDate"], task["IsCompleted"], task["Type"]);
                i++;
            }
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("Press Any Key To Continue");
            Console.ReadKey();
        }
    }
}
