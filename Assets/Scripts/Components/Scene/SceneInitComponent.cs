using System;
using Helpers;
using Managers.Data;
using ScriptableObjects.Scenes;
using UnityEngine;

namespace Components.Scene
{
    public class SceneInitComponent : MonoBehaviour
    {
        public SceneInfo sceneInfo;
        public InitSceneData initSceneData;
        public SpawnerManagerComponent spawnerManagerComponent;

        private void Init()
        {
            if (sceneInfo == null)
            {
                Debug.LogError("not assigned sceneInfo information");
                throw new Exception();
            }

            SceneDataManager.SetCurrentSceneInfo(sceneInfo);
            
            if (initSceneData == null)
            {
                Debug.LogError("not assigned initSceneData information");
                throw new Exception();
            }

            if (spawnerManagerComponent == null)
            {
                spawnerManagerComponent = GameObject.FindObjectOfType<SpawnerManagerComponent>();
                if (spawnerManagerComponent != null) 
                    return;
                
                Debug.LogError("can't find SpawnerManagerComponent");
                throw new Exception();
            }
        }
        
        private void LoadPlayer()
        {
            var player = Instantiate(initSceneData.player) as GameObject;
            if (player == null)
            {
                Debug.LogError("not assigned player information in current InitSceneData object");
                throw new Exception();
            }
            
            var playerTransform = player.transform;
            
            var spawners = SpawnerHelper.ComponentsToSpawnObjects(spawnerManagerComponent.spawnerComponents);
            var spawner = SpawnerHelper.CurrentSpawner(spawners);
            
            var currentSpawnerTransform = SpawnerHelper.SpawnerTransformBySpawnId(spawnerManagerComponent.spawnerComponents, spawner.SpawnId());

            TransformHelper.CopyTransform(ref playerTransform, currentSpawnerTransform);
        }

        private void Awake()
        {
            Init();
        }

        private void Start()
        {
            LoadPlayer();
        }
    }
}