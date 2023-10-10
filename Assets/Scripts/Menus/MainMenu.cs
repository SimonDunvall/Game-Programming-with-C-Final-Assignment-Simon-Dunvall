using Game;
using UnityEngine;

namespace Menus
{
    public class MainMenu : MonoBehaviour
    {
        public void RunGame()
        {
            GameState.LoadTrack();
            //GameState.LoadCars();
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}