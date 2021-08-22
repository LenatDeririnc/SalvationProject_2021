using System;
using Components.Player;
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
        }

        private void ChangeScene()
        {
            var sceneName = spawnRelocation.Scene().name;
        
            SpawnerHelper.SetCurrentSpawner(spawnRelocation);
            SceneManager.LoadScene(spawnRelocation.Scene().SceneName());
        }

        public void OpenDoor()
        {
            Debug.Assert(spawnRelocation != null, $"spawnRelocation not assigned for object \"{gameObject.name}\"");
            FadeOutComponent.fadeOutSignal += ChangeScene;
            StartCoroutine(m_fadeOutComponent.FadeIn(0.1f));
            
            PlayerComponent.setEnableLook.Invoke(false);
            PlayerComponent.setEnableMovement.Invoke(false);
            PlayerComponent.setEnableInteract.Invoke(false);
        }
    }
}
