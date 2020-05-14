using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Student_Management_System.Manager
{
    class File_Manager
    {
        public class FileManager : IDisposable
        {
            private Dictionary<string, Student.Student> dict;

            private static string DataFile = Path.Combine(Path.GetTempPath(), "data.json");

            public FileManager()
            {

                if (File.Exists(DataFile))
                {
                    dict = JsonConvert.DeserializeObject<Dictionary<string, Student.Student>>(File.ReadAllText(DataFile));
                }
                else
                    dict = new Dictionary<string, Student.Student>();
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
                    dict = JsonConvert.DeserializeObject<Dictionary<string, Student.Student>>(File.ReadAllText(DataFile));
                }
                else
                    dict = new Dictionary<string, Student.Student>();
            }

            public void AddValue(string key, Student.Student value)
            {
                dict.Add(key, value);
            }

            public void Remove(string key)
            {
                if (dict.ContainsKey(key))
                {
                    dict.Remove(key);
                    Console.WriteLine("Student " + key + " is removed from database");

                }
                else {
                    Console.WriteLine("Name "+key +" does not exsist in the database" );
                }
            }

            public void Dispose()
            {
                var json = JsonConvert.SerializeObject(dict);
                File.WriteAllText(DataFile, json);
            }

            public Dictionary<string, Student.Student> GetValues()
            {
                return dict;
            }

        }
    }
}
