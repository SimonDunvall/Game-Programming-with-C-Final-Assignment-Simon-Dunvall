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
            GameState.pauseGame(GetComponent<Canvas>());

            winner.text = $"The winner is {carName}";
        }
    }
}