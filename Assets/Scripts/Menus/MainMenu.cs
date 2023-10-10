using System;
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

        public void Settings()
        {
            throw new NotImplementedException();
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