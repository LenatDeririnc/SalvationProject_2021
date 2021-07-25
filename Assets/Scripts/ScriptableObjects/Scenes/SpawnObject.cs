using UnityEngine;

namespace ScriptableObjects.Scenes
{
    [CreateAssetMenu(fileName = "SpawnObject", menuName = "ScriptableObjects/Scene/SpawnObject", order = 0)]
    public class SpawnObject : ScriptableObject
    {
        public string spawnId;
    }
}