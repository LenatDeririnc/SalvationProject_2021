using System;
using Components.Scene;
using Components.UI;
using Helpers;
using ScriptableObjects.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Components.GameObjects
{
    public class DoorObject : MonoBehaviour
    {
        [SerializeField] private SpawnObject spawnRelocation;
        private FadeOutComponent m_fadeOutComponent;

        void Start()
        {
            m_fadeOutComponent ??= FindObjectOfType<FadeOutComponent>();
            Debug.Assert(m_fadeOutComponent != null, "can't find FadeOutComponent in scene");

            FadeOutComponent.fadeOutSignal = null;
            FadeOutComponent.fadeOutSignal += ChangeScene;
        }

        private void ChangeScene()
        {
            SpawnerHelper.SetCurrentSpawner(spawnRelocation);
            SceneManager.LoadScene(spawnRelocation.Scene().name);
        }

        public void OpenDoor()
        {
            Debug.Assert(spawnRelocation != null, $"spawnRelocation not assigned for object \"{gameObject.name}\"");
            StartCoroutine(m_fadeOutComponent.FadeIn(0.1f));
            //TODO: Отнять управление движением у игрока
        }
    }
}
