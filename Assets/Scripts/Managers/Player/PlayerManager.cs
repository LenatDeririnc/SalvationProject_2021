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
        private static IPlayer gameCamera;
        
        public static Action onPlayerSpawn;
        public static Action<bool> setEnableMovement;
        public static Action<bool> setEnableLook;
        public static Action<bool> setEnableInteract;
        public static Action<float> setWalkSpeed;
        
        public delegate float FloatAction();
        
        public static FloatAction walkSpeed;
        public static FloatAction defaultWalkSpeed;

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

        public static GameObject LoadPlayer(InitSceneData initSceneData, SpawnerManagerComponent spawnerManagerComponent)
        {
            var player = initSceneData.player as GameObject;
            Debug.Assert(player != null, "not assigned player information in current InitSceneData object");

            PlayerManager.SetPlayer(player.GetComponent<IPlayer>());

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

        public static void SetEnableMovement(bool state)
        {
            setEnableMovement.Invoke(state);
        }

        public static void SetEnableLook(bool state)
        {
            setEnableLook.Invoke(state);
        }

        public static void SetEnableInteract(bool state)
        {
            setEnableInteract.Invoke(state);
        }


        public static void SetWalkSpeed(float value)
        {
            setWalkSpeed.Invoke(value);
        }

        public static float WalkSpeed()
        {
            return walkSpeed.Invoke();
        }

        public static float DefaultWalkSpeed()
        {
            return defaultWalkSpeed.Invoke();
        }
    }
}