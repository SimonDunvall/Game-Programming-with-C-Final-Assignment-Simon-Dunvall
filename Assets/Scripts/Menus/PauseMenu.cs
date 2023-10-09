using Game;
using UnityEngine;

namespace Menus
{
    public class PauseMenu : MonoBehaviour
    {
        public void MainMenu()
        {
            Canvas canvas = gameObject.GetComponentInParent<Canvas>();
            GameState.unPauseGame(canvas);
            GameState.LoadMainMenu();
        }

        public void ResumeGame()
        {
            Canvas canvas = gameObject.GetComponentInParent<Canvas>();
            GameState.unPauseGame(canvas);
        }
    }
}