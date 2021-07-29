using UnityEngine;

namespace ScriptableObjects.Scenes
{
    [CreateAssetMenu(fileName = "SpawnObject", menuName = "ScriptableObjects/Scene/SpawnObject", order = 0)]
    public class SpawnObject : ScriptableObject
    {
        [SerializeField] private SceneInfo scene;
        [SerializeField] private string spawnId;

        public string SpawnId() => spawnId;
        public SceneInfo Scene() => scene;
    }
}