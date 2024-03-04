using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskManager2.Abstract;
using TaskManager2.Storage;

namespace TaskManager2.Core
{
    class TaskManager
    {

        public List<ITask> TaskList { get; private set; }
        public string Name { get; private set; }
        private IState _state;
        public StorageManager ListStorageManager { get; private set; }

        public TaskManager()
        {
            TaskList = new List<ITask>();      

            ListStorageManager = new StorageManager();

        }

        public List<Dictionary<string,object>> GetAllTasksSummary() {
            List<Dictionary<string, object>> summaryList = new List<Dictionary<string, object>>();
            foreach (ITask task in TaskList) {
                summaryList.Add(task.GetDictionaryTask());
            }


            return summaryList;
        }

        public void AddTask(ITask task) {
            TaskList.Add(task);
        }



        public void NewTaskList(string name) {
           
            ListStorageManager.New(name);
            Name = name;
        }

        public bool IsTaskListClosed() {
            return TaskList.Count == 0 && Name == null;
        }

        public void CloseTaskList() {
                TaskList.Clear();
                Name = null;
                ListStorageManager = new StorageManager();
        }

        public void OpenTaskList(string name) {
            TaskList = ListStorageManager.Get(name);
            Name = name;
        }

        public void SaveTaskList() {
            ListStorageManager.Save(TaskList);
        }

        public void DeleteTaskList(string name) {
            ListStorageManager.Delete(name);
            Name = null;
            ListStorageManager = new StorageManager();
        }

        public void SwitchState(IState state)
        {
            _state = state;
        }

        public string[] SearchAllTaskLists() {
            return ListStorageManager.SearchFiles();
        }

        public void Run(IState initialState)
        {

            _state = initialState;

            while (true)
            {
                _state.Render();
                Console.ForegroundColor = ConsoleColor.Green;
                var command = _state.GetCommand();
                Console.ForegroundColor = ConsoleColor.White;
                command.Execute();
            }

        }

    }
}
