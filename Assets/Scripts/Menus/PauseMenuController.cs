using Game;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Menus
{
    public class PauseMenuController : MonoBehaviour
    {
        private static PauseMenuController instance;
        private static GameSettings gameSettings;

        internal void Initialize(GameSettings settings)
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);

                gameSettings = settings;
                return;
            }

            Destroy(gameObject);
        }

        [SerializeField] private InputActionAsset primaryActions;
        private InputActionMap pauseMenuActionMap;
        private InputAction pauseMenuInputAction;

        private void Awake()
        {
            pauseMenuActionMap = primaryActions.FindActionMap("PauseMenu");

            pauseMenuInputAction = pauseMenuActionMap.FindAction("Pause Game");

            pauseMenuInputAction.performed += PauseGame;
        }

        private void OnEnable()
        {
            pauseMenuInputAction?.Enable();
        }

        private void OnDisable()
        {
            pauseMenuInputAction?.Disable();
        }

        private void PauseGame(InputAction.CallbackContext context)
        {
            if (SceneManager.GetActiveScene().name == gameSettings.mainMenuSceneName) return;
            Canvas canvas = UiController.GetCanvas(instance.gameObject);

            if (!gameSettings.isGamePaused)
            {
                GameState.pauseGame(canvas);
            }
            else
            {
                GameState.unPauseGame(canvas);
            }
        }
    }
}