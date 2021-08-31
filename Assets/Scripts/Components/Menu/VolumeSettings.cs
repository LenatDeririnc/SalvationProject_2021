using UnityEngine;

namespace Components.Menu
{
    public class VolumeSettings : MonoBehaviour
    {
        public float changeValue = 9;
        public void ChangeVolume(float volume)
        {
            AudioListener.volume = volume / changeValue;
        }
    }
}