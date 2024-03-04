using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager2.Abstract;

namespace TaskManager2.Commands {
    class ExitProgramCommand : ICommand {
        public void Execute() {
            Environment.Exit(Environment.ExitCode);
        }
    }
}
