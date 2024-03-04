﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager2.Abstract;
using TaskManager2.Commands;
using TaskManager2.Core;

namespace TaskManager2.States {
    class OpenTaskListState : IState {

        private TaskManager _manager;
        private IState _lastState;
        private TaskManager manager;

        public OpenTaskListState(TaskManager manager) {
            this.manager = manager;
        }

        public OpenTaskListState(TaskManager manager, IState lastState) {
            _manager = manager;
            _lastState = lastState;
        }
        public ICommand GetCommand() {
            string command = Console.ReadLine();

            if (command == "back") {
                return new SwitchStateCommand(_manager, _lastState);

            }
            if (command == "files") {
                return new SearchAllTaskListsCommand(_manager);

            }
            if (command == "open") {
                return  new OpenTaskListCommand(_manager);
            }

            return new InvalidCommand();
        }

        public void Render() {
            Console.WriteLine("[back] - Back");
            Console.WriteLine("[files] - Show All Saved Task Lists");
            Console.WriteLine("[open] - Open Task List");
        }
    }
}
