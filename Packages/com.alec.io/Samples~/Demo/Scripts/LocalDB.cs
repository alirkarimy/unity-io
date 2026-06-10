using com.alec.io;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;


public static partial class LocalDB
{
    //public static Dictionary<string, object> dbRootRef = new Dictionary<string, object>();
    //public static Dictionary<string, object> dbSettingsRef = null;



    #region Initialization

    public static void Initialize(Action<DBCreationStatus> OnDBInitialized)
    {
        //lock (dbRootRef)
        //{
        //    if (IO.IsDBCreated() == false)
        //    {

        //        dbSettingsRef = new Dictionary<string, object>();
        //        dbRootRef.Add("settings", dbSettingsRef);

        //        //Set initial data
        //        IO.Save(dbRootRef);

        //    }
        //    else
        //        Load();

            OnDBInitialized?.Invoke(DBCreationStatus.Succeed);

        //}

    }


    //public static void Load()
    //{
    //    IO.Load(out dbRootRef);
    //    // Retrieve and cast the nested dictionary
    //    dbSettingsRef = JsonConvert.DeserializeObject<Dictionary<string, object>>(dbRootRef["settings"].ToString());
    //    dbRootRef["settings"] = dbSettingsRef;


    //}

    #endregion



}

public enum DBCreationStatus
{
    Failed,
    Succeed
}