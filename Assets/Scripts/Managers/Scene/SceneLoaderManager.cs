using Helpers;
using ScriptableObjects.Scenes;
using UnityEngine.SceneManagement;

namespace Managers.Scene
{
    public static class SceneLoaderManager
    {
        public static void LoadScene(SceneInfo Scene)
        {
            SceneManager.LoadScene(Scene.SceneName());
        }

        public static void LoadSceneAndSpawnPlayer(SpawnObject spawnRelocation)
        {
            SpawnerHelper.SetCurrentSpawner(spawnRelocation);
            SceneLoaderManager.LoadScene(spawnRelocation.Scene());
        }
    }
}