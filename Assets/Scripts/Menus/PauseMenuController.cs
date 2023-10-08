using Game;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Menus
{
    public class PauseMenuController : MonoBehaviour
    {
        private static PauseMenuController instance;

        private void Initialize()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                return;
            }

            Destroy(gameObject);
        }

        public InputActionAsset primaryActions;
        private InputActionMap pauseMenuActionMap;
        private InputAction pauseMenuInputAction;

        private void Awake()
        {
            Initialize();
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
            var canvas = instance.GetComponent<Canvas>();
            if (!GameState.isGamePaused())
            {
                GameState.pauseGame();
                canvas.enabled = true;
            }
            else
            {
                GameState.unPauseGame();
                canvas.enabled = false;
            }
        }
    }
}