using Game;
using UnityEngine;

namespace Menus
{
    public class PauseMenu : MonoBehaviour
    {
        public void MainMenu()
        {
            var canvas = gameObject.GetComponentInParent<Canvas>();
            GameState.unPauseGame(canvas);
            GameState.LoadMainMenu();
        }

        public void ResumeGame()
        {
            var canvas = gameObject.GetComponentInParent<Canvas>();
            GameState.unPauseGame(canvas);
        }
    }
}