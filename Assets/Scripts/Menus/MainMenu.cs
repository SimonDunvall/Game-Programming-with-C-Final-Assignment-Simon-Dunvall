using UnityEngine;

namespace Menus
{
    public class MainMenu : MonoBehaviour
    {
        public void RunGame()
        {
            gameObject.GetComponentInParent<Canvas>().enabled = false;
            FindFirstObjectByType<TrackMenu>().gameObject.GetComponentInParent<Canvas>().enabled = true;
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