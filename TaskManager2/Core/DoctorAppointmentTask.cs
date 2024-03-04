using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager2.Abstract;

namespace TaskManager2.Core {
    class DoctorAppointmentTask : GeneralTask, ITask {
        private string _type = "Medical Appointment";
        public string Illness = "";
        public string Doctor;
        public int DaysRest = 0;
        public DoctorAppointmentTask(string title, string notes, DateTime dueDate, Priority taskPriority, string doctor) 
            : base(title, notes, dueDate, taskPriority) {
            Doctor = doctor;
        }

        public override Dictionary<string, object> GetDictionaryTask() {
            Dictionary<string, object> dic = base.GetDictionaryTask();
            dic["Illness"] = Illness;
            dic["Doctor"] = Doctor;
            dic["DaysRest"] = DaysRest;
            dic["Type"] = _type;
            return dic;
        }

        public override void TaskCompleted() {
             
        }

    }
}
