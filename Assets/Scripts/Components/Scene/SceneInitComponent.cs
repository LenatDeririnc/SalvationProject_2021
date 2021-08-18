using System;
using Components.Player;
using Components.UI;
using Helpers;
using Interfaces.Player;
using Managers.Data;
using Managers.Player;
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
            if (FindObjectOfType<PlayerComponent>() != null)
                return;

            var player = Instantiate(initSceneData.player) as GameObject;
            Debug.Assert(player != null, "not assigned player information in current InitSceneData object");

            PlayerManager.player = player.GetComponent<IPlayer>();

            var playerTransform = player.transform;
            
            var spawners = SpawnerHelper.ComponentsToSpawnObjects(spawnerManagerComponent.spawnerComponents);
            var spawner = SpawnerHelper.CurrentSpawner(spawners);
            
            var currentSpawnerTransform = SpawnerHelper.SpawnerTransformBySpawnId(spawnerManagerComponent.spawnerComponents, spawner.SpawnId());

            TransformHelper.CopyTransform(ref playerTransform, currentSpawnerTransform);
        }

        private void LoadFadeOutComponent()
        {
            if (FindObjectOfType<FadeOutComponent>() != null)
                return;

            var fadeOutComponent = Instantiate(initSceneData.FadeOutObject) as GameObject;
            Debug.Assert(fadeOutComponent != null, "not assigned FadeOutObject information in current InitSceneData object");
        }

        private void Awake()
        {
            Init();
            LoadPlayer();
            LoadFadeOutComponent();
        }
    }
}