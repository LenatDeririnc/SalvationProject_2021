using UnityEngine;

namespace Components.Menu
{
    public class ExitGame : MonoBehaviour
    {
        public void Exit()
        {
            Application.Quit();
        }
    }
}