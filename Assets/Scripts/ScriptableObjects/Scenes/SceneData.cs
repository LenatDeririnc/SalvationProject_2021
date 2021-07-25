using UnityEngine;

namespace ScriptableObjects.Scenes
{
    [CreateAssetMenu(fileName = "SceneData", menuName = "ScriptableObjects/Scene/SceneData", order = 1)]
    public class SceneData : ScriptableObject
    {
        [SerializeField] private string sceneName;

        // 0-ой спавнер - спавнер по умолчанию, который должен быть всегда в случае возникновения ошибок.
        [SerializeField] private SpawnObject[] spawns;

        public string SceneName() => sceneName;
    }   
}
