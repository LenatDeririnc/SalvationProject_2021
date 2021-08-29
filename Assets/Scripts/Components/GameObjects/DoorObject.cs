using System;
using Components.Player;
using Components.Player.PlayerVariations;
using Components.Scene;
using Components.UI;
using Helpers;
using Managers.Player;
using Managers.Scene;
using Managers.UI;
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
        }

        private void ChangeScene()
        {
            SceneLoaderManager.LoadSceneAndSpawnPlayer(spawnRelocation);
        }

        public void OpenDoor()
        {
            Debug.Assert(spawnRelocation != null, $"spawnRelocation not assigned for object \"{gameObject.name}\"");
            FadeInOutManager.fadeInSignal += ChangeScene;
            FadeInOutManager.FadeIn(this, FadeInOutManager.DefaultDoorFadeInSpeed());

            PlayerManager.SetEnableLook(false);
            PlayerManager.SetEnableMovement(false);
            PlayerManager.SetEnableInteract(false);
        }
    }
}
