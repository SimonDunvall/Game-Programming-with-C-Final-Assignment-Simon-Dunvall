using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    private static GameState instance;
    private GameSettings gameSettings;

    public void Initialize()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LogGameState("Game Initialized");

            LoadSettings();
            LoadTrack();

            return;
        }

        LogGameState("Duplicate instance instantiated, destroying...");
        Destroy(gameObject);
    }

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void LoadSettings()
    {
        gameSettings = Resources.Load<GameSettings>("GameSettings");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        if (scene.name == gameSettings.tracksName[0])
        {
            Debug.Log("Game Started. Track01 scene loaded");
        }
    }

    private void LoadTrack()
    {
        SceneManager.LoadSceneAsync(gameSettings.tracksName[0], LoadSceneMode.Single);
    }

    private static void LogGameState(string message)
    {
        Debug.Log(message);
    }
}