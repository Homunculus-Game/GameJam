using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private string _dataFilepath;

    private void Awake()
    {
        _dataFilepath = Path.Combine(Application.persistentDataPath, "SaveGameData.json");
        Debug.Log(_dataFilepath);
    }

    public void PlayGame()
    {
        ResourceManager.albedoCount = 3;
        ResourceManager.rubedoCount = 3;
        ResourceManager.nigredoCount = 0;
        ResourceManager.failedCount = 0;

        ResourceManager.newGame = true;

        ResourceManager.currentDay = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SaveGame()
    {
        GameData gameData = new GameData();
        // gameData.day = ResourceManager.instance.currentDay;
        gameData.albedoCount = ResourceManager.albedoCount;
        gameData.rubedoCount = ResourceManager.rubedoCount;
        gameData.nigredoCount = ResourceManager.nigredoCount;
        gameData.failedCount = ResourceManager.failedCount;
        // gameData.level = SceneManager.GetActiveScene().buildIndex;
        // gameData.health = PlayerController.currentHealth;
        // gameData.xp = PlayerController.experience;
        // gameData.position = PlayerController.gameObject.transform.position;


        using StreamWriter writer = new StreamWriter(_dataFilepath);
        string dataToWrite = JsonUtility.ToJson(gameData);

        writer.Write(dataToWrite);

        Debug.Log("was saved :)");
    }

    public void LoadGame()
    {
        // This creates a StreamReader, which allows us to read the data from the specified file path
        // using StreamReader reader = new StreamReader(_dataFilepath);
        // // We read in the file as a string
        // string dataToLoad = reader.ReadToEnd();
        // 
        // // Here we convert the JSON formatted string into an actual Object in memory
        // GameData gameData = JsonUtility.FromJson<GameData>(dataToLoad);
        // 
        // ResourceManager.test = gameData.day;
        // // ResourceManager.currentDay = gameData.day;
        // ResourceManager.albedoCount = gameData.albedoCount;
        // ResourceManager.rubedoCount = gameData.rubedoCount;
        // ResourceManager.nigredoCount = gameData.nigredoCount;
        // ResourceManager.failedCount = gameData.failedCount;
        // //PlayerController.currentHealth = gameData.health;
        // //PlayerController.experience = gameData.xp;
        // //PlayerController.numProjectiles = gameData.ammo;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Debug.Log("was loaded :)");
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application quit.");
    }
}
