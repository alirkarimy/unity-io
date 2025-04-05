using com.alec.io;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;


public static partial class LocalDB
{
    public static Dictionary<string, object> dbRootRef = null;
    public static Dictionary<string, object> dbBooksRef = null;
    public static Dictionary<string, object> dbChaptersRef = null;


    #region Initialization

    public static void Initialize(Action<DBCreationStatus> OnDBInitialized)
    {
        object lockObject = new();
        lock (lockObject)
        {
            if (IO.IsDBCreated() == false)
            {
                dbRootRef = new Dictionary<string, object>();
                dbBooksRef = new Dictionary<string, object>();
                dbChaptersRef = new Dictionary<string, object>();
                dbRootRef.Add("books", dbBooksRef);
                dbRootRef.Add("chapters", dbChaptersRef);
                PlayerPrefs.SetInt("InitializeLocalDB", 1);
                //Set initial data
                IO.Save(dbRootRef);

            }
            else
                Load();

            OnDBInitialized?.Invoke(DBCreationStatus.Succeed);

        }

    }


    public static void Load()
    {
        dbRootRef = IO.Load();
        // Retrieve and cast the nested dictionary
        dbBooksRef = JsonConvert.DeserializeObject<Dictionary<string, object>>(dbRootRef["books"].ToString());
        dbRootRef["books"] = dbBooksRef;

        dbChaptersRef = JsonConvert.DeserializeObject<Dictionary<string, object>>(dbRootRef["chapters"].ToString());
        dbRootRef["chapters"] = dbChaptersRef;


       
    }

    #endregion

   

}

public enum DBCreationStatus
{
    Failed,
    Succeed
}