using Menus;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameState : MonoBehaviour
    {
        private static GameState instance;
        private static GameSettings gameSettings;

        public void Initialize(GameSettings settings)
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);

                gameSettings = settings;

                LoadMainMenu();

                return;
            }

            LogGameState("Duplicate instance instantiated, destroying...");
            Destroy(gameObject);
        }

        public static void LoadMainMenu()
        {
            SceneManager.LoadSceneAsync(gameSettings.mainMenuSceneName, LoadSceneMode.Single);
        }

        public static void LoadPauseMenu()
        {
            var pauseMenuPrefab = Resources.Load<PauseMenuController>("pauseMenuCanvas");
            Instantiate(pauseMenuPrefab);
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