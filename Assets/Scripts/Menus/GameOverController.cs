using Game;
using TMPro;
using UnityEngine;

namespace Menus
{
    public class GameOverController : MonoBehaviour
    {
        [SerializeField] private TMP_Text winner;

        internal void GameWon(string carName)
        {
            GameState.pauseGame(UiController.GetGameOverCanvas());
            UiController.WriteText(winner, $"The winner is {carName}");
        }
    }
}