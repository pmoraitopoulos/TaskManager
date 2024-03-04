using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager2.Core {
    class FileExistsException : Exception {
        public DateTime Timestamp { get; }
        public FileExistsException() : base("This file already exists.") {
            Timestamp = DateTime.Now;
        }
       
    }

     
}
