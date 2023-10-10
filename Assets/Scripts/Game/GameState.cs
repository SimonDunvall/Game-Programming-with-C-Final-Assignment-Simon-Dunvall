using Car;
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
                LoadPauseMenu();

                return;
            }

            Destroy(gameObject);
        }

        private void Awake()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == gameSettings.mainMenuSceneName) return;

            LoadCars();
        }

        internal static void LoadMainMenu()
        {
            SceneManager.LoadSceneAsync(gameSettings.mainMenuSceneName, LoadSceneMode.Single);
        }

        private static void LoadPauseMenu()
        {
            PauseMenuController pauseMenuPrefab = Resources.Load<PauseMenuController>("pauseMenuCanvas");
            PauseMenuController pauseMenuController = Instantiate(pauseMenuPrefab);
            pauseMenuController.Initialize(gameSettings);
        }

        internal static void LoadTrack(int trackNumber)
        {
            SceneManager.LoadSceneAsync(gameSettings.tracksName[trackNumber], LoadSceneMode.Single);
        }

        public static void pauseGame(Canvas canvas)
        {
            gameSettings.isGamePaused = true;
            canvas.enabled = true;
            Time.timeScale = 0;
        }

        public static void unPauseGame(Canvas canvas)
        {
            gameSettings.isGamePaused = false;
            canvas.enabled = false;
            Time.timeScale = 1;
        }

        public static int getNumberOfLaps()
        {
            return gameSettings.numberOfLaps;
        }

        private static void LoadCars()
        {
            Instantiate(Resources.Load<CarData>("car_root01"));
            Instantiate(Resources.Load<CarData>("car_root02"));
        }
    }
}