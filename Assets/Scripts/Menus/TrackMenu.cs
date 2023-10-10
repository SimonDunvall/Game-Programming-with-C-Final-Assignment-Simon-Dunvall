using Game;
using UnityEngine;

namespace Menus
{
    public class TrackMenu : MonoBehaviour
    {
        public int trackNumber;

        public void ChooseTrack()
        {
            GameState.LoadTrack(trackNumber);
        }
    }
}