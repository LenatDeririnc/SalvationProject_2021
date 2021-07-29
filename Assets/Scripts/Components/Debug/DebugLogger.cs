using UnityEngine;

namespace Components
{
    public class DebugLogger : MonoBehaviour
    {
        public void Log(string message)
        {
            UnityEngine.Debug.Log(message);
        }
    }   
}
