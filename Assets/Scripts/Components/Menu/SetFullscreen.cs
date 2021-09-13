using UnityEngine;
using UnityEngine.UI;

namespace Components.Menu
{
    public class SetFullscreen : MonoBehaviour
    {
        [SerializeField] private bool fullscreen;
        [SerializeField] private Toggle toggle;
    
        void Start()
        {
            fullscreen = Screen.fullScreen;
            toggle.isOn = fullscreen;
        }

        public void Set(bool state)
        {
            fullscreen = state;
        
            Screen.fullScreen = fullscreen;
            if (fullscreen)
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
    }
}
