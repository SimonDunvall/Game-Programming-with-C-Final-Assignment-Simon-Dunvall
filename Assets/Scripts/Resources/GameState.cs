using UnityEngine;
using UnityEngine.SceneManagement;

namespace Resources
{
    public class GameState : MonoBehaviour
    {
        private static GameState instance;

        public void Initialize()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                LogGameState("Game Initialized");
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

        private static void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
            if (scene.name == "MainMenu")
            {
                Debug.Log("Game Started. MainMenu scene loaded");
            }
        }

        private static void LoadTrack()
        {
            SceneManager.LoadSceneAsync("MainMenu");
        }

        private static void LogGameState(string message)
        {
            Debug.Log(message);
        }
    }
}