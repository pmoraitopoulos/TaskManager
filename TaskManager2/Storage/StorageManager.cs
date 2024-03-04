using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskManager2.Abstract;
using TaskManager2.Core;

namespace TaskManager2.Storage {
    class StorageManager {

        public const string TaskListDirectory = "TaskLists\\";
        private string _fullTaskListPath;
        private string _name;
        // να φύγει από εδώ το τασκ μανατζερ και να γίνει με αντίστοιχες μεθόδους στο τασκ μανατζερ όλες οι εκτελέσεις

        public StorageManager() {


            var directoryFullName = new DirectoryInfo(TaskListDirectory).FullName;
            if (!Directory.Exists(TaskListDirectory)) {
                Directory.CreateDirectory(TaskListDirectory);
                Console.WriteLine("Storage Directory Created. Path: {0}", directoryFullName);
            } else {
                Console.WriteLine("Storage Directory Found. Path: {0}", directoryFullName);
            }
            


        }

        public void New(string name) {
            
            if (!FileExists(name)) {
                _name = name;
                _fullTaskListPath = Path.Combine(TaskListDirectory, _name + ".json");

                File.Create(_fullTaskListPath).Close();

            } else {
                throw new FileExistsException();
            }


        }

        public static bool FileExists(string fileName) {

            string path = Path.Combine(TaskListDirectory, fileName + ".json");
            if (File.Exists(path)) {
                return true;
            }
            return false;
            
        }

        public void Save(List<ITask> taskList) {
            if (FileExists(_name)) {
                var fileStream = File.Open(_fullTaskListPath, FileMode.Truncate, FileAccess.Write);

                string data = SerializeTaskList(taskList);
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                fileStream.Write(dataBytes, 0, dataBytes.Length);
                fileStream.Close();
            }

        }

        public List<ITask> Get(string name) {
            if (FileExists(name) ) {
                _name = name;
                _fullTaskListPath = Path.Combine(TaskListDirectory, _name + ".json");
                return DeserializeTaskList(this.ReadFile(_fullTaskListPath));
            }else {
                throw new FileNotFoundException();
            }
            
        }

        public void Delete(string name) {

            if (FileExists(name)) {
                _name = null;
                _name = name;
                _fullTaskListPath = Path.Combine(TaskListDirectory, _name + ".json");
                File.Delete(_fullTaskListPath);
            } else {
                throw new FileNotFoundException();
            }

        }

        public string[] SearchFiles() {
            string[] fileInfo = Directory.GetFiles(TaskListDirectory);
            return fileInfo;
        }

        private string ReadFile(string path) {
            byte[] fileBytes = File.ReadAllBytes(path);

            // Convert the bytes to a string
            string fileContent = Encoding.UTF8.GetString(fileBytes);
            return fileContent;
        }

        private string SerializeTaskList(List<ITask> TaskList) {

            string taskListJson = JsonConvert.SerializeObject(TaskList, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto } );

            return taskListJson;
        }

        private List<ITask> DeserializeTaskList(string taskListJson) {
            List<ITask> recreatedTaskList = JsonConvert.DeserializeObject<List<ITask>>(taskListJson, new JsonSerializerSettings {
                TypeNameHandling = TypeNameHandling.Auto
            });

            return recreatedTaskList;
        }

    }
}
