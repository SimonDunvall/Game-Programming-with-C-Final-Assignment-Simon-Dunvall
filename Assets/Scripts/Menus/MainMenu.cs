using UnityEngine;

namespace Menus
{
    public class MainMenu : MonoBehaviour
    {
        public void RunGame()
        {
            UiController.TurnOfParentCanvasForGameObject(gameObject);
            UiController.TurnOnParentCanvasForGameObject(FindFirstObjectByType<TrackMenu>().gameObject);
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