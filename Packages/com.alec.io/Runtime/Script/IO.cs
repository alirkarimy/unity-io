using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace com.alec.io
{

    public static partial class IO
    {
        private const string _name = "/localdb";
        private static readonly string _path = GetMainPath();


        public static bool IsDBCreated(string dbName = _name)
        {
            Debug.Log(_path + dbName);
            return File.Exists(Path.Combine(_path , dbName));
        }

        public static bool HasResourcesDB(string dbName = _name)
        {
            Debug.Log("resources" + Resources.Load<TextAsset>(dbName));

            return Resources.Load<TextAsset>(dbName) != null;
        }

        private static string GetMainPath()
        {
            return Application.persistentDataPath;
        }

        public static void Save(Dictionary<string, object> dbRootRef, string dbName = _name)
        {
            File.WriteAllText(Path.Combine(_path, dbName), JsonConvert.SerializeObject(dbRootRef, Formatting.Indented));
        }
        public static void Save<T>(T dbRootRef, string dbName = _name) 
        {
           
            Debug.Log(_path + dbName);
            
            File.WriteAllText(Path.Combine(_path, dbName), JsonConvert.SerializeObject(dbRootRef, Formatting.Indented));
        }

        public static void Load(out Dictionary<string, object> loadedData, string dbName = _name)
        {
            if (IsDBCreated(dbName)==false)
            {
                Debug.LogError($"No stored data with dbname {dbName}");
                loadedData = default;
                return;
            }
            loadedData = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(Path.Combine(_path, dbName)));
        }
        public static void LoadFromResources(out string loadedData, string dbName = _name)
        {
            if (HasResourcesDB(dbName) == false)
            {
                Debug.LogError($"No stored data with dbname {dbName}");
                loadedData = string.Empty;
                return;
            }
            TextAsset jsonFile = Resources.Load<TextAsset>(dbName); // "config" is the name of the JSON file without the extension

            loadedData = jsonFile.text;
        }
        public static void Load(out string loadedData, string dbName = _name)
        {
            if (IsDBCreated(dbName)==false)
            {
                Debug.LogError($"No stored data with dbname {dbName}");
                loadedData = string.Empty;
                return;
            }
            loadedData = File.ReadAllText(Path.Combine(_path, dbName));
        }

    }
}