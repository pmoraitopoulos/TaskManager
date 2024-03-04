using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager2.Core;
using Newtonsoft.Json;

namespace TaskManager2.Abstract
{
    interface ITask {

        Dictionary<string, object> GetDictionaryTask();

        void TaskCompleted();
    }
}
