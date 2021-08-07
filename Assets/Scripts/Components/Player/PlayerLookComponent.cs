using System;
using Managers.Player;
using Managers.Player.CameraRotateBehaviours;
using UnityEngine;

namespace Components.Player
{
    public class PlayerLookComponent : MonoBehaviour, ILook
    {
        [SerializeField] private bool m_enabled = true;

        private PlayerCamera m_camera;
        private CameraRotateBehaviour m_cameraRotateBehaviour;

        public bool Enabled() => m_enabled;
        public void SetEnabled(bool enabled) => m_enabled = enabled;
        public CameraRotateBehaviour LookBehaviour() => m_cameraRotateBehaviour;

        public void SetLookBehaviour(CameraRotateBehaviour value)
        {
            m_cameraRotateBehaviour = value;
        }

        public PlayerCamera Camera()
        {
            m_camera ??= GetComponentInChildren<PlayerCamera>();
            return m_camera;
        }

        private void Awake()
        {
            Camera();
            m_cameraRotateBehaviour = new InputRotate(m_camera);
        }

        void Update()
        {
            if (m_cameraRotateBehaviour.UseFixedUpdate())
                return;
            
            m_cameraRotateBehaviour.Rotate();
        }

        void FixedUpdate()
        {
            if (!m_cameraRotateBehaviour.UseFixedUpdate())
                return;
            
            m_cameraRotateBehaviour.Rotate();
        }
    }
}