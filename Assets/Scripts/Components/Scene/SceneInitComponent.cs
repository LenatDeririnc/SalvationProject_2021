using Helpers;
using ScriptableObjects.Scenes;
using UnityEngine;

namespace Components.Scene
{
    public class SceneInitComponent : MonoBehaviour
    {
        public OnSceneLoadData onSceneLoadData;
        public SpawnerManagerComponent spawnerManagerComponent;

        private void Init()
        {
            if (spawnerManagerComponent == null)
                spawnerManagerComponent = GameObject.FindObjectOfType<SpawnerManagerComponent>();
            
            if (spawnerManagerComponent == null)
                Debug.LogError("can't find SpawnerManagerComponent");
        }
        
        private void LoadPlayer()
        {
            var player = Instantiate(onSceneLoadData.player) as GameObject;
            var playerTransform = player.transform;
            
            var spawners = SpawnerHelper.ComponentsToSpawnObjects(spawnerManagerComponent.spawnerComponents);
            var spawner = SpawnerHelper.CurrentSpawner(spawners);
            
            var currentSpawnerTransform = SpawnerHelper.SpawnerTransformBySpawnId(spawnerManagerComponent.spawnerComponents, spawner.spawnId);

            TransformHelper.CopyTransform(ref playerTransform, currentSpawnerTransform);
        }
        
        private void Start()
        {
            Init();
            LoadPlayer();
        }
    }
}