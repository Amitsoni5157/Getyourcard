using Newtonsoft.Json;
using UnityEngine;
using System.IO;

public class GameSaveService
{

    public PairEnum leveltype;
    public const string SaveDirectory = "/SaveData";



 
    public GameSaveService()
    {

    }

    public void SaveCurrentGame(CardGameData cgameData, string filename)
    {
        string jsonv = JsonConvert.SerializeObject(cgameData);
        var dir = Application.persistentDataPath + SaveDirectory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        File.WriteAllText(dir + "/"+filename+".txt", jsonv);

        //GUIUtility.systemCopyBuffer = dir + FileName;
    }

    public CardGameData loadSavedGame(string filename)
    {
       // CardGameData _cardgamedata;
        var LoadFile = Application.persistentDataPath + SaveDirectory + "/" + filename + ".txt";
        if (File.Exists(LoadFile))
        {
            string readFile = File.ReadAllText(LoadFile);
            CardGameData getJsonv = JsonConvert.DeserializeObject<CardGameData>(readFile);
            return getJsonv;
        }

        return null;
    }

    public void DeleteSaveFile(string fileName)
    {
        var SavedFile = Application.persistentDataPath + SaveDirectory + "/" + fileName + ".txt";
        if (File.Exists(SavedFile))
        {
            File.Delete(SavedFile);
        }

    }
}
