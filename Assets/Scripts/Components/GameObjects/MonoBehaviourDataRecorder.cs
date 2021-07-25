using Managers.Data;
using UnityEngine;

namespace Components.GameObjects
{
    public class MonoBehaviourDataRecorder : MonoBehaviour
    {
        protected void SetDataValue(string valueName, object value)
        {
            var sceneName = SceneDataManager.CurrentSceneInfo().SceneName();
            SceneDataManager.SetSceneValue(sceneName, valueName, value);
        }

        protected object GetDataValue(string valueName)
        {
            var sceneName = SceneDataManager.CurrentSceneInfo().SceneName();
            return SceneDataManager.SceneValue(sceneName, valueName);
        }
    }
}