using System.Globalization;
using TaskManager2.Abstract;
using TaskManager2.Core;
using TaskManager2.States;

namespace TaskManager2 {
    public class Program {

        
        static void Main(string[] args) {

            Console.WriteLine("TaskManager starting...");
            TaskManager manager = new TaskManager();
            manager.Run(new OpeningState(manager));
        }
    }
}