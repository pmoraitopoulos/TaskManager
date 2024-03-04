using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager2.Abstract {
    interface IState {

        void Render();
        ICommand GetCommand();

        
    }
}
