using TMPro;
using UnityEngine;

namespace Menus
{
    public abstract class UiController : MonoBehaviour
    {
        internal static void WriteText(TMP_Text tmpText, string s)
        {
            tmpText.text = s;
        }

        internal static Canvas GetGameOverCanvas()
        {
            return FindObjectOfType<GameOverController>().GetComponent<Canvas>();
        }

        internal static void TurnOfParentCanvasForGameObject(GameObject gameObject)
        {
            gameObject.GetComponentInParent<Canvas>().enabled = false;
        }

        internal static void TurnOnParentCanvasForGameObject(GameObject gameObject)
        {
            gameObject.GetComponentInParent<Canvas>().enabled = true;
        }

        internal static Canvas GetParentCanvasFromGameObject(GameObject gameObject)
        {
            return gameObject.GetComponentInParent<Canvas>();
        }

        internal static Canvas GetCanvas(GameObject gameObject)
        {
            return gameObject.GetComponent<Canvas>();
        }
    }
}