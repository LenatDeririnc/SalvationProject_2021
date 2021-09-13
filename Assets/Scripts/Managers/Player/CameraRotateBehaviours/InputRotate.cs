using Components.Player;
using UnityEngine;

namespace Managers.Player.CameraRotateBehaviours
{
    public class InputRotate : CameraRotateBehaviour
    {
        private PlayerCamera m_playerCamera;

        public InputRotate(PlayerCamera playerCamera)
        {
            m_playerCamera = playerCamera;
        }
        
        public override bool UseFixedUpdate() => false;

        public override void Rotate()
        {
            var input = InputManager.LookAxis();
            var x = Mathf.Clamp(m_playerCamera.Pitch + input.y, -m_playerCamera.MaxPitch, m_playerCamera.MaxPitch);
            m_playerCamera.Pitch = x;
            var y = m_playerCamera.transform.localRotation.eulerAngles.y + input.x;
            m_playerCamera.transform.localRotation = Quaternion.Euler(new Vector3(x, y));
        }
    }
}