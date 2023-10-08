using Game;
using UnityEngine;

namespace Menus
{
    public class PauseMenu : MonoBehaviour
    {
        public void MainMenu()
        {
            var canvas = gameObject.GetComponentInParent<Canvas>();
            canvas.enabled = false;
            GameState.LoadMainMenu();
        }

        public void ResumeGame()
        {
            GameState.unPauseGame();
            var canvas = gameObject.GetComponentInParent<Canvas>();
            canvas.enabled = false;
        }
    }
}