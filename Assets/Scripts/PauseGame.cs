using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    private string _dataFilepath;

    public static bool isPaused = false;

    private void Start()
    {
        _pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        _pauseMenu.SetActive(false);
    }

    private void Pause()
    {
        isPaused = true;
        Time.timeScale = 0.0f;
        _pauseMenu.SetActive(true);
    }

    public void LoadGame()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Debug.Log("was loaded :)");
    }

    public void LoadMainMenu()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
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
}
