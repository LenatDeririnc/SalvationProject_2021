using System;
using Interfaces.Player;
using Managers.Player.CameraRotateBehaviours;
using UnityEngine;

namespace Components.Player.LookVariations
{
    public class CameraLookComponent : MonoBehaviour, ILook
    {
        [SerializeField] private PlayerCamera m_camera;
        
        private CameraRotateBehaviour m_cameraRotateBehaviour;

        private void Awake()
        {
            m_cameraRotateBehaviour = new StaticRotate();
        }

        public bool Enabled() => true;

        public void SetEnabled(bool state)
        {
            Debug.LogWarning("can't unset look of static camera");
        }

        public PlayerCamera Camera()
        {
            m_camera ??= GetComponentInChildren<PlayerCamera>();
            return m_camera;
        }

        public CameraRotateBehaviour LookBehaviour() => m_cameraRotateBehaviour;

        public void SetLookBehaviour(CameraRotateBehaviour value)
        {
            Debug.LogWarning("can't set rotate behaviour to camera");
        }
    }
}