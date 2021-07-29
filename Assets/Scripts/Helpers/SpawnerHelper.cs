using System.Linq;
using Components;
using Components.Scene;
using ScriptableObjects.Scenes;
using UnityEngine;

namespace Helpers
{
    public static class SpawnerHelper
    {
        public static SpawnObject[] ComponentsToSpawnObjects(SpawnObjectComponent[] spawners)
        {
            SpawnObject[] spawnObjects = new SpawnObject[spawners.Length];
            for (int i = 0; i < spawners.Length; ++i)
            {
                spawnObjects[i] = spawners[i].SpawnInfo();
            }

            return spawnObjects;
        }
        
        public static Transform SpawnerTransformBySpawnId(SpawnObjectComponent[] spawners, string spawnId)
        {
            if (spawners.Length <= 0)
            {
                UnityEngine.Debug.LogError("spawner container is empty");
                return null;
            }

            foreach (var spawner in spawners)
            {
                if (spawnId == spawner.SpawnInfo().SpawnId())
                    return spawner.Transform();
            }
            
            UnityEngine.Debug.LogError("unacceptable spawnId name");
            return null;
        }
        
        public static Transform[] SpawnerTransforms(SpawnObjectComponent[] spawners)
        {
            Transform[] retVal = new Transform[spawners.Length];

            for (int i = 0; i < spawners.Length; ++i)
            {
                SpawnObjectComponent spawn = spawners[i];
                var trans = spawn.Transform();
                retVal[i] = trans;
            }

            return retVal;
        }

        public static SpawnObject CurrentSpawner(SpawnObject[] spawnObjects)
        {
            if (!spawnObjects.Contains(SpawnerStaticData.currentSpawner))
            {
                if (SpawnerStaticData.currentSpawner == null)
                    Debug.LogWarning($"Current spawn object is null. Setting current spawn object to default spawner.");
                else 
                    Debug.LogWarning($"Unacceptable current spawn object. Setting current spawn object to default spawner.");
                SpawnerStaticData.currentSpawner = spawnObjects[0];
            }

            return SpawnerStaticData.currentSpawner;
        }

        public static void SetCurrentSpawner(SpawnObject newSpawn)
        {
            SpawnerStaticData.currentSpawner = newSpawn;
        }
    }
}