using Helpers;
using ScriptableObjects.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Components.Scene
{
    public class SceneLoaderComponent : MonoBehaviour
    {
        public void LoadScene(SceneData sceneData)
        {
            var name = sceneData.SceneName();
            SceneManager.LoadScene(name);
        }

        public void SetCurrentSpawner(SpawnObject spawnObject)
        {
            SpawnerHelper.SetCurrentSpawner(spawnObject);
        }
    }
}
