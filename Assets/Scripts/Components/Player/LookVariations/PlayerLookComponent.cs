using Interfaces.Player;
using Managers.Player.CameraRotateBehaviours;
using UnityEngine;

namespace Components.Player.LookVariations
{
    [RequireComponent(typeof(IPlayer))]
    public class PlayerLookComponent : MonoBehaviour, ILook
    {
        [SerializeField] private bool m_enabled = true;

        private PlayerCamera m_camera;
        private CameraRotateBehaviour m_cameraRotateBehaviour;

        public bool Enabled() => m_enabled;
        public void SetEnabled(bool state) => m_enabled = state;
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
            if (!m_enabled || m_cameraRotateBehaviour.UseFixedUpdate())
                return;
            
            m_cameraRotateBehaviour.Rotate();
        }

        void FixedUpdate()
        {
            if (!m_enabled || !m_cameraRotateBehaviour.UseFixedUpdate())
                return;
            
            m_cameraRotateBehaviour.Rotate();
        }
    }
}