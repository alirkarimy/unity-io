using Newtonsoft.Json;
using System;
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
            return File.Exists(_path + dbName);
        }

        private static string GetMainPath()
        {
            return Application.persistentDataPath;
        }

        public static void Save( Dictionary<string, object> dbRootRef, string dbName = _name)
        {
            File.WriteAllText(_path + dbName, JsonConvert.SerializeObject(dbRootRef, Formatting.Indented));
        }

        public static Dictionary<string, object> Load(string dbName = _name)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(_path + dbName));
        }


    }
}