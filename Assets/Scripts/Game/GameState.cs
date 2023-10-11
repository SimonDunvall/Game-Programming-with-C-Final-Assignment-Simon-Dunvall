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

        internal void Initialize(GameSettings settings)
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

            LoadGameOver();
            LoadCars();
        }

        private void LoadGameOver()
        {
            GameOverController gameOverPrefab = Resources.Load<GameOverController>("gameOverCanvas");
            Instantiate(gameOverPrefab);
        }

        private static void LoadPauseMenu()
        {
            PauseMenuController pauseMenuPrefab = Resources.Load<PauseMenuController>("pauseMenuCanvas");
            PauseMenuController pauseMenuController = Instantiate(pauseMenuPrefab);
            pauseMenuController.Initialize(gameSettings);
        }

        internal static void LoadMainMenu()
        {
            SceneManager.LoadSceneAsync(gameSettings.mainMenuSceneName, LoadSceneMode.Single);
        }

        internal static void LoadTrack(int trackNumber)
        {
            SceneManager.LoadSceneAsync(gameSettings.tracksName[trackNumber], LoadSceneMode.Single);
        }

        internal static void pauseGame(Canvas canvas)
        {
            gameSettings.isGamePaused = true;
            canvas.enabled = true;
            Time.timeScale = 0;
        }

        internal static void unPauseGame(Canvas canvas)
        {
            gameSettings.isGamePaused = false;
            canvas.enabled = false;
            Time.timeScale = 1;
        }

        private static void LoadCars()
        {
            Instantiate(Resources.Load<CarData>("car_root01")).name = "car1";
            Instantiate(Resources.Load<CarData>("car_root02")).name = "car2";
        }
    }
}