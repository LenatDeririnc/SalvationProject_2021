using UnityEngine;

namespace ScriptableObjects.Scenes
{
    [CreateAssetMenu(fileName = "SceneData", menuName = "ScriptableObjects/Scene/SceneData", order = 0)]
    public class SceneInfo : ScriptableObject
    {
        [SerializeField] private string sceneName;

        // NOTE: 0-ой спавнер - спавнер по умолчанию, который должен быть всегда в случае возникновения ошибок.
        [SerializeField] private SpawnObject[] spawns;

        public string SceneName() => sceneName;

        public override string ToString()
        {
            return sceneName;
        }
    }   
}
