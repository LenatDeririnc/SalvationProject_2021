using Managers.Data;
using UnityEngine;

namespace ScriptableObjects.Scenes
{
    [CreateAssetMenu(fileName = "GameObjectDataHolder", menuName = "ScriptableObjects/GameObjectDataHolder", order = 0)]
    public class GameObjectDataHolder : ScriptableObject
    {
        [SerializeField] private SceneInfo m_sceneInfo;

        private void Awake()
        {
            Debug.Assert(m_sceneInfo != null, $"sceneInfo not assigned for scriptable object: {name}");
        }

        public object Value()
        {
            return SceneDataManager.SceneValue(m_sceneInfo.SceneName(), name);
        }

        public void SetObjectValue<T>(T val)
        {
            SceneDataManager.SetSceneValue(m_sceneInfo.SceneName(), name, val);
        }

        public void SetObjectValueBool(bool val) => SetObjectValue(val);

        public void SetObjectValueInt(int val) => SetObjectValue(val);

        public void SetObjectValueFloat(float val) => SetObjectValue(val);

        public void SetObjectValueString(string val) => SetObjectValue(val);
    }
}