using Menus;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameState : MonoBehaviour
    {
        private static GameState instance;
        private static GameSettings gameSettings;

        public void Initialize()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);

                LoadSettings();
                LoadMainMenu();
                LoadPauseMenu();

                return;
            }

            LogGameState("Duplicate instance instantiated, destroying...");
            Destroy(gameObject);
        }

        private void LoadMainMenu()
        {
            SceneManager.LoadSceneAsync(gameSettings.mainMenuSceneName, LoadSceneMode.Single);
        }

        private void LoadPauseMenu()
        {
            var pauseMenuPrefab = Resources.Load<PauseMenu>("pauseMenuCanvas");
            var pauseMenuController = Instantiate(pauseMenuPrefab);
            pauseMenuController.Initialize();
        }

        private void LoadSettings()
        {
            gameSettings = Resources.Load<GameSettings>("GameSettings");
        }

        public static void LoadTrack()
        {
            SceneManager.LoadSceneAsync(gameSettings.tracksName[0], LoadSceneMode.Single);
        }

        private void LogGameState(string message)
        {
            Debug.Log(message);
        }

        public static void pauseGame()
        {
            gameSettings.isGamePaused = true;
            Time.timeScale = 0;
        }

        public static void unPauseGame()
        {
            gameSettings.isGamePaused = false;
            Time.timeScale = 1;
        }

        public static bool isGamePaused()
        {
            return gameSettings.isGamePaused;
        }

        public static int getNumberOfLaps()
        {
            return gameSettings.numberOfLaps;
        }
    }
}