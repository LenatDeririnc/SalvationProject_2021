using UnityEngine;

namespace ScriptableObjects.Scenes
{
    [CreateAssetMenu(fileName = "InitSceneData", menuName = "ScriptableObjects/InitSceneData", order = 0)]
    public class InitSceneData : ScriptableObject
    {
        public Object player;
        public Object FadeOutObject;
    }
}