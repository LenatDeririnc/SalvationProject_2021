using Components.Scene;
using Helpers;
using ScriptableObjects.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Components.GameObjects
{
    public class DoorObject : MonoBehaviour
    {
        [SerializeField] private SpawnObject spawnRelocation;

        public void OpenDoor()
        {
            Debug.Assert(spawnRelocation != null, $"spawnRelocation not assigned for object \"{gameObject.name}\"");
            //NOTE: Сюда можно будет вставить логику появления фейд-аутов
            
            SpawnerHelper.SetCurrentSpawner(spawnRelocation);
            SceneManager.LoadScene(spawnRelocation.Scene().name);
        }
    }
}
