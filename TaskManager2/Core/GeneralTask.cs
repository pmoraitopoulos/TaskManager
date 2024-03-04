using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager2.Abstract;

namespace TaskManager2.Core
{
    class GeneralTask : ITask {
        private string _type = "General";
        public string Title { get; set; }
        public string Notes { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public Priority TaskPriority { get; set; }
        DateTime CompletedDate { get; set; }

        public GeneralTask(string title, string notes, DateTime dueDate, Priority taskPriority)
        {
            Title = title;
            Notes = notes;
            DueDate = dueDate;
            IsCompleted = false;
            TaskPriority = taskPriority;
            CompletedDate = new DateTime();
        }
        
        public virtual Dictionary<string, object> GetDictionaryTask()
        {
            Dictionary<string, object> taskData = new Dictionary<string, object>();
            taskData["Title"] = this.Title;
            taskData["Notes"] = this.Notes;
            taskData["DueDate"] = this.DueDate;
            taskData["IsCompleted"] = this.IsCompleted;
            taskData["TaskPriority"] = this.TaskPriority;
            taskData["Completed Date"] = this.CompletedDate;
            taskData["Type"] = _type;


            return taskData;

        }

        public virtual void TaskCompleted() {
            this.IsCompleted = true;
        }
    }
}
