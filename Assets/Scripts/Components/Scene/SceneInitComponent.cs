using System;
using System.ComponentModel;
using Components.Functions;
using Components.Player;
using Components.Player.PlayerVariations;
using Components.UI;
using Helpers;
using Interfaces.Player;
using Managers.Data;
using Managers.Player;
using Managers.UI;
using ScriptableObjects.Scenes;
using UnityEngine;

namespace Components.Scene
{
    public class SceneInitComponent : MonoBehaviour
    {
        public SceneInfo sceneInfo;
        public InitSceneData initSceneData;
        public SpawnerManagerComponent spawnerManagerComponent;
        public bool doNotLoadPlayer = false;

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
                
                Debug.LogWarning("can't find SpawnerManagerComponent");
            }
        }
        
        private void Awake()
        {
            Init();

            if (FindObjectOfType<PlayerComponent>() == null && !doNotLoadPlayer)
            {
                var player = Instantiate(PlayerManager.LoadPlayer(initSceneData, spawnerManagerComponent));
                PlayerManager.SetPlayer(player);
            }

            if (FindObjectOfType<FadeOutComponent>() == null)
                Instantiate(FadeInOutManager.LoadFadeOutComponent(initSceneData));
        }
    }
}