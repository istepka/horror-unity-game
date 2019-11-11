using UnityEngine;

public class SaveGame
{

    //serialized
    public string PlayerName = "Player";
    public int XP = 0;
    public static Vector3 PlayerPosition = PlayerController.playerPosition;


    private static string _gameDataFileName = "data.json";

    private static SaveGame _instance;
    public static SaveGame Instance
    {
        get
        {
            if (_instance == null)
                Load();
            return _instance;
        }

    }

    public static void Save()
    {
        PlayerController.savePlayerPosition();
        
        FileManager.Save(_gameDataFileName, _instance);
    }

    public static void Load()
    {
        _instance = FileManager.Load<SaveGame>(_gameDataFileName);
    }

}