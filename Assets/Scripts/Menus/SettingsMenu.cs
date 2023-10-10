using Game;
using UnityEngine;

namespace Menus
{
    public class SettingsMenu : MonoBehaviour
    {
        public void TopDownView()
        {
            GameState.chooseCamera(0);
            gameObject.GetComponentInParent<Canvas>().enabled = false;
            FindFirstObjectByType<MainMenu>().gameObject.GetComponentInParent<Canvas>().enabled = true;
        }

        public void SplitScreen()
        {
            GameState.chooseCamera(1);
            gameObject.GetComponentInParent<Canvas>().enabled = false;
            FindFirstObjectByType<MainMenu>().gameObject.GetComponentInParent<Canvas>().enabled = true;
        }
    }
}