using Game;
using TMPro;
using UnityEngine;

namespace Menus
{
    public class GameOverController : MonoBehaviour
    {
        public TMP_Text winner;

        public void GameWon(string carName)
        {
            GameState.pauseGame(GetCanvas());

            winner.text = $"The winner is {carName}";
        }

        internal static Canvas GetCanvas()
        {
            return FindObjectOfType<GameOverController>().GetComponent<Canvas>();
        }
    }
}