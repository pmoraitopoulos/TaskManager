using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager2.Abstract;
using TaskManager2.Commands;
using TaskManager2.Core;

namespace TaskManager2.States {
    class CreateNewTaskState : IState {

        private TaskManager _manager;
        private IState _lastState;

        public CreateNewTaskState(TaskManager manager, IState lastState) {
            _manager = manager;
            _lastState = lastState;

        }
        public ICommand GetCommand() {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Task List : {0}", _manager.Name);
            Console.ForegroundColor = ConsoleColor.White;
            string command = Console.ReadLine();
            if (command =="back") {
                return new SwitchStateCommand(_manager, _lastState);
            }
            if (command =="gnr") {
                return new CreateNewGenetalTaskCommand();
            } 
            if (command =="doc") {
                return new CreateNewDoctorAppointmentCommand();
            }


            return new InvalidCommand();
        }

        public void Render() {
            Console.WriteLine("[back] - Back");
            Console.WriteLine("[gnr] - General Task");
            Console.WriteLine("[doc] - Medical Appointment");
        }
    }
}
