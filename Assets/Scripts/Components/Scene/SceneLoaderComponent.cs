using Helpers;
using ScriptableObjects.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Components.Scene
{
    public class SceneLoaderComponent : MonoBehaviour
    {
        public void LoadScene(SceneInfo sceneInfo)
        {
            var name = sceneInfo.SceneName();
            SceneManager.LoadScene(name);
        }

        public void SetCurrentSpawner(SpawnObject spawnObject)
        {
            SpawnerHelper.SetCurrentSpawner(spawnObject);
        }
    }
}
