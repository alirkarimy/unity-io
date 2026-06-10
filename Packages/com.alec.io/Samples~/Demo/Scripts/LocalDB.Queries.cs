
using Alec.App.AppBootstrap;
using Booali.Network.Api;
using com.alec.io;
using Newtonsoft.Json;
using Palgam.PalgamApp.Scripts.RedesignScripts.PalgamWebRequest.Sockets.GameSockets;
using System;
using UnityEngine;

public static partial class LocalDB
{
    internal static partial class Path
    {
        internal static readonly string USERDATA_DB_PATH = "userdata";
        internal static readonly string APPSTATE_DB_PATH = "appstate";
        internal static readonly string SAMPLE_MATCH_RESPONSE_PATH = "samplematchresponse";
        internal static readonly string LOADOUT_PATH = "player_loadout";
    }
    internal static partial class Queries
    {

        #region Book Data

        internal static void UpdateAppState(AppState appstate)
        {
            if (appstate == null) return;

            IO.Save(appstate, Path.APPSTATE_DB_PATH);
        }
        internal static AppState GetAppState()
        {
            if (IO.IsDBCreated(Path.APPSTATE_DB_PATH) == false) return null;

            IO.Load(out string appstateJSON, Path.APPSTATE_DB_PATH);
            AppState appstateModel = JsonConvert.DeserializeObject<AppState>(appstateJSON);
            appstateModel.IsNetworkInitialized = false;

            return appstateModel;
        }
       
        internal static MatchRoot GetSampleMatchResponse()
        {
            //if (dbRootRef == null) Initialize((result) => { });
            if (IO.HasResourcesDB(Path.SAMPLE_MATCH_RESPONSE_PATH) == false) { Debug.Log(134343); return null; }

            IO.LoadFromResources(out string settingsJSON, Path.SAMPLE_MATCH_RESPONSE_PATH);
            MatchRoot samplematch = JsonConvert.DeserializeObject<MatchRoot>(settingsJSON);
            return samplematch;
        }

        
        #endregion


    }
}


