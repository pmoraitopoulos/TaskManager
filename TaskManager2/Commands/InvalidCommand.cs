using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager2.Abstract;

namespace TaskManager2.Commands
{
    class InvalidCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Unknown Command. Please select one of the followings.");
        }
    }
}
