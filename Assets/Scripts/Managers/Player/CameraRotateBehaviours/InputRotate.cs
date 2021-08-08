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
            var input = new Vector2(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
            var x = Mathf.Clamp(m_playerCamera.Pitch + input.x, -m_playerCamera.MaxPitch, m_playerCamera.MaxPitch);
            m_playerCamera.Pitch = x;
            var y = m_playerCamera.transform.localRotation.eulerAngles.y + input.y;
            m_playerCamera.transform.localRotation = Quaternion.Euler(new Vector3(x, y));
        }
    }
}