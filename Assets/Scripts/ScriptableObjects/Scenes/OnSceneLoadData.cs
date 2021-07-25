using UnityEngine;

namespace ScriptableObjects.Scenes
{
    [CreateAssetMenu(fileName = "OnSceneLoadData", menuName = "ScriptableObjects/OnSceneLoadData", order = 0)]
    public class OnSceneLoadData : ScriptableObject
    {
        public Object player;
    }
}