using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager2.Abstract;

namespace TaskManager2.Commands {
    internal class NullCommand : ICommand {
        public void Execute() {
           //Nothing here. Continue.
        }
    }
}
