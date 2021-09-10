using Components.Player;
using UnityEngine;

namespace Managers.Player.CameraRotateBehaviours
{
    public class TargetRotate : CameraRotateBehaviour
    {
        private PlayerCamera m_playerCamera;
        private readonly Transform m_target;
        private readonly float m_speed;

        public TargetRotate(PlayerCamera playerCamera, Transform target, float speed)
        {
            m_target = target;
            m_speed = speed;
            m_playerCamera = playerCamera;
        }
        
        public override bool UseFixedUpdate() => true;

        private static float WrapAngle(float angle)
        {
            angle %= 360;
            if(angle > 180)
                return angle - 360;
 
            return angle;
        }
        
        public override void Rotate()
        {
            Vector3 targetDirection = m_target.position - m_playerCamera.transform.position;
            var lookRotation = Quaternion.LookRotation(targetDirection);
            m_playerCamera.transform.rotation = Quaternion.Lerp(m_playerCamera.transform.rotation, lookRotation, m_speed);

            var angle = m_playerCamera.transform.localRotation.eulerAngles.x;
            
            m_playerCamera.Pitch = WrapAngle(angle);
        }
    }
}