using System;
using Components.Player.PlayerVariations;
using Components.Scene;
using Helpers;
using Interfaces.Player;
using ScriptableObjects.Scenes;
using UnityEngine;

namespace Managers.Player
{
    public enum Views
    {
        PlayerView,
        GameCameraView
    }
    
    public static class PlayerManager
    {
        private static IPlayer player;

        public static Action onPlayerSpawn;
        public static Action<bool> setEnableMovement;
        public static Action<bool> setEnableLook;
        public static Action<bool> setEnableInteract;
        public static Action<float> setWalkSpeed;
        
        public delegate float FloatAction();
        
        public static FloatAction walkSpeed;
        public static FloatAction defaultWalkSpeed;
        
        private static IPlayer gameCamera;
        public static Action onCameraSpawn;
        public static Action<Vector3> setCameraPosition;
        public static Action<Quaternion> setCameraRotation;
        
        public static Action<Vector3> setPlayerPosition;
        public static Action<Quaternion> setPlayerRotation;

        public static void SwitchView(Views view)
        {
            switch (view)
            {
                case Views.PlayerView:
                    PlayerPrefs.SetInt("UnitySelectMonitor", 0);
                    break;
                case Views.GameCameraView:
                    PlayerPrefs.SetInt("UnitySelectMonitor", 1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(view), view, null);
            }
        }

        public static IPlayer Player()
        {
            Debug.Assert(PlayerManager.player != null, "can't find player in player manager");
            return PlayerManager.player;
        }

        public static void SetPlayer(IPlayer player)
        {
            PlayerManager.player = player;
        }
        
        public static void SetPlayer(GameObject player)
        {
            PlayerManager.player = player.GetComponent<IPlayer>();
        }

        public static GameObject LoadPlayer(InitSceneData initSceneData, SpawnerManagerComponent spawnerManagerComponent)
        {
            var player = initSceneData.player as GameObject;
            Debug.Assert(player != null, "not assigned player information in current InitSceneData object");

            var playerTransform = player.transform;
            
            var spawners = SpawnerHelper.ComponentsToSpawnObjects(spawnerManagerComponent.spawnerComponents);
            var spawner = SpawnerHelper.CurrentSpawner(spawners);
            
            var currentSpawnerTransform = SpawnerHelper.SpawnerTransformBySpawnId(spawnerManagerComponent.spawnerComponents, spawner.SpawnId());

            TransformHelper.CopyTransform(ref playerTransform, currentSpawnerTransform);

            return player;
        }

        public static IPlayer GameCamera()
        {
            Debug.Assert(PlayerManager.gameCamera != null, "can't find player in player manager");
            return PlayerManager.gameCamera;
        }

        public static void SetGameCamera(IPlayer gameCamera)
        {
            PlayerManager.gameCamera = gameCamera;
        }

        public static void OnPlayerSpawn()
        {
            if (PlayerManager.onPlayerSpawn != null)
                PlayerManager.onPlayerSpawn.Invoke();
        }

        public static void OnGameCameraSpawn()
        {
            if (PlayerManager.onCameraSpawn != null)
                PlayerManager.onCameraSpawn.Invoke();
        }

        public static void SetEnableMovement(bool state)
        {
            if (setEnableMovement == null)
            {
                Debug.LogWarning("can't set movement enable, player has not created!");
                return;
            }

            setEnableMovement.Invoke(state);
        }

        public static void SetEnableLook(bool state)
        {
            if (setEnableLook == null)
            {
                Debug.LogWarning("can't set look enable, player has not created!");
                return;
            }
            
            setEnableLook.Invoke(state);
        }

        public static void SetEnableInteract(bool state)
        {
            if (setEnableInteract == null)
            {
                Debug.LogWarning("can't set interact enable, player has not created!");
                return;
            }
            
            setEnableInteract.Invoke(state);
        }


        public static void SetWalkSpeed(float value)
        {
            if (setWalkSpeed == null)
            {
                Debug.LogWarning("can't set walk speed, player has not created!");
                return;
            }
            
            setWalkSpeed.Invoke(value);
        }

        public static float WalkSpeed()
        {
            if (walkSpeed == null)
            {
                Debug.LogWarning("can't get walk speed, player has not created!");
                return 0;
            }
            
            return walkSpeed.Invoke();
        }

        public static float DefaultWalkSpeed()
        {
            if (defaultWalkSpeed == null)
            {
                Debug.LogWarning("can't get default walk speed, player has not created!");
                return 0;
            }
            
            return defaultWalkSpeed.Invoke();
        }

        public static void SetPlayerPosition(Vector3 position)
        {
            if (setPlayerPosition == null)
            {
                Debug.LogWarning("can't set player position, player has not created!");
                return;
            }
            
            setPlayerPosition.Invoke(position);
        }
        
        public static void SetPlayerRotation(Quaternion rotation)
        {
            if (setPlayerRotation == null)
            {
                Debug.LogWarning("can't set player rotation, player has not created!");
                return;
            }
            
            setPlayerRotation.Invoke(rotation);
        }

        public static void SetCameraPosition(Vector3 position)
        {
            if (setCameraPosition == null)
            {
                Debug.LogWarning("can't set camera position, camera has not created!");
                return;
            }
            
            setCameraPosition.Invoke(position);
        }

        public static void SetCameraRotation(Quaternion rotation)
        {
            if (setCameraRotation == null)
            {
                Debug.LogWarning("can't set camera rotation, camera has not created!");
                return;
            }
            
            setCameraRotation.Invoke(rotation);
        }
    }
}