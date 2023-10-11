using Game;
using UnityEngine;

namespace Menus
{
    public class PauseMenu : MonoBehaviour
    {
        public void MainMenu()
        {
            Canvas canvas = UiController.GetParentCanvasFromGameObject(gameObject);
            GameState.unPauseGame(canvas);
            GameState.LoadMainMenu();
        }

        public void ResumeGame()
        {
            Canvas canvas = UiController.GetParentCanvasFromGameObject(gameObject);
            GameState.unPauseGame(canvas);
        }
    }
}