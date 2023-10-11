using Game;
using UnityEngine;

namespace Menus
{
    public class TrackMenu : MonoBehaviour
    {
        [SerializeField] private int trackNumber;

        public void ChooseTrack()
        {
            GameState.LoadTrack(trackNumber);
        }
    }
}