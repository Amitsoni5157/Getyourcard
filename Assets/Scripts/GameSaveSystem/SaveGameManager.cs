using System.IO;
using UnityEngine;

namespace SaveinSystem
{
    public static class SaveGameManager
    {
     //   public static GameSaveData currentSaveData = new GameSaveData();
        public const string SaveDirectory = "/SaveData";
        public const string FileName = "/SaveGame.sav";



        public static bool Save()
        {

            var dir = Application.persistentDataPath + SaveDirectory;

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

          //  string json = JsonUtility.ToJson(currentSaveData,true);
          //  File.WriteAllText(dir + FileName,json);

            GUIUtility.systemCopyBuffer = dir + FileName;

            return true;
        }
    }
    /*  public int Turn_temp;
            public float Time_temp;
            public int Score_temp;*/
   
}