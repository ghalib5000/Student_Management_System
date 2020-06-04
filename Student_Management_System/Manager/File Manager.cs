using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using BasicLogger;

namespace Student_Management_System.Manager
{
    class File_Manager
    {
        public class FileManager : IDisposable
        {
            private Dictionary<int, Student.Student> dict;

            private static string DataFile = Path.Combine(Path.GetTempPath(), "data.json");
            public static Logger log = new Logger("Student_log.txt", DateTime.Now.ToString());
            public FileManager()
            {

                if (File.Exists(DataFile))
                {
                    dict = JsonConvert.DeserializeObject<Dictionary<int, Student.Student>>(File.ReadAllText(DataFile));
                }
                else
                    dict = new Dictionary<int, Student.Student>();
            }

            public FileManager(string location)
            {

                string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\files\\";
                if (!Directory.Exists(currentPath))
                {
                    Directory.CreateDirectory(currentPath);
                }
                DataFile = Path.Combine(currentPath + location);
                if (File.Exists(DataFile))
                {
                    dict = JsonConvert.DeserializeObject<Dictionary<int, Student.Student>>(File.ReadAllText(DataFile));
                }
                else
                    dict = new Dictionary<int, Student.Student>();
            }

            public void AddValue(int key, Student.Student value)
            {

                dict.Add(key, value);
              
            }


            public void Remove(int key)
            {
                if (dict.ContainsKey(key))
                {
                    dict.Remove(key);
                    string temp = "Student with ID: " + key + " is removed from database";
                    Console.WriteLine(temp);
                    log.Information(temp);

                }
                else
                {
                    string temp = "ID " + key + " does not exist in the database";
                    Console.WriteLine(temp);
                    log.Information(temp);
                }
            }
            public void Remove(int key,string name)
            {
                if (dict.ContainsKey(key))
                {
                    
                    dict.Remove(key);
                    string temp = "Student " + name + " is removed from database";
                    //Console.WriteLine(temp);
                    log.Information(temp);

                }
                else
                {
                    string temp = "Name " + name + " does not exist in the database";
                    Console.WriteLine(temp);
                    log.Information(temp);
                }
            }

            public void Dispose()
            {
                var json = JsonConvert.SerializeObject(dict);
                File.WriteAllText(DataFile, json);
            }

            public Dictionary<int, Student.Student> GetValues()
            {
                return dict;
            }

        }
    }
}
