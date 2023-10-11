using Game;
using UnityEngine;

namespace Menus
{
    public class GameOverMenu : MonoBehaviour
    {
        public void ToMainMenu()
        {
            GameState.unPauseGame(UiController.GetGameOverCanvas());
            GameState.LoadMainMenu();
        }
    }
}