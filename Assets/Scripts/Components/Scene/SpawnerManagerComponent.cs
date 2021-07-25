using ScriptableObjects.Scenes;
using UnityEngine;

namespace Components.Scene
{
    public static class SpawnerStaticData
    {
        public static SpawnObject currentSpawner;
    }
    public class SpawnerManagerComponent : MonoBehaviour
    {
        public SpawnObjectComponent[] spawnerComponents;

        private void LoadSpawners()
        {
            spawnerComponents = GetComponentsInChildren<SpawnObjectComponent>();
        }

        private void Awake()
        {
            if (spawnerComponents.Length <= 0)
                LoadSpawners();
        }
    }
   
}