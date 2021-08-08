using System;
using Managers.Player;
using UnityEngine;

namespace Components.Player
{
    public class LookAtComponent : MonoBehaviour
    {
        public float speed = 0.1f;
        public float maxPitch = 89;
        
        [SerializeField] private bool m_enabled = true;
        public bool Enabled() => m_enabled;
        public void SetEnabled(bool enabled) => this.m_enabled = enabled;

        private ILook m_lookComponent;
        
        private Transform m_cameraObject;
        
        [SerializeField] private Transform m_target;
        public Transform Target() => m_target;
        public void SetTarget(Transform target) => m_target = target;
        
        private float m_pitch = 0;

        private void Awake()
        {
            m_lookComponent ??= GetComponent<ILook>();
            m_cameraObject ??= m_lookComponent.Camera();
        }

        // private void AlphaRotate(Vector3 rotateVector)
        // {
        //     var cameraRotation = m_cameraObject.localRotation.eulerAngles;
        //     
        //     cameraRotation = new Vector3(m_pitch, cameraRotation.y) + rotateVector;
        //     cameraRotation.x = Mathf.Clamp(cameraRotation.x, -maxPitch, maxPitch);
        //     m_pitch = cameraRotation.x;
        //     
        //     m_cameraObject.localRotation = Quaternion.Euler(cameraRotation);
        // }

        private void TargetRotate(Vector3 targetPosition, float speed)
        {
            var localRotation = m_cameraObject.localRotation;
            var cameraRotation = localRotation.eulerAngles;

            Vector3 direction = (targetPosition - m_cameraObject.position).normalized;
            // var directionUp = Vector3.ProjectOnPlane(direction, Vector3.up).normalized;
            // var directionRight = Vector3.ProjectOnPlane(direction, m_cameraObject.right).normalized;
            
            var lookRotation = Quaternion.LookRotation(direction);
            // var lookRotationRight = Quaternion.LookRotation(directionRight);
            
            cameraRotation = new Vector3(m_pitch, cameraRotation.y) + lookRotation.eulerAngles;
            cameraRotation.x = Mathf.Clamp(cameraRotation.x, -maxPitch, maxPitch);
            m_pitch = cameraRotation.x;
            
            localRotation = Quaternion.Lerp(localRotation, Quaternion.Euler(cameraRotation), speed);
            m_cameraObject.localRotation = localRotation;
        }

        void Update()
        {
            if (!m_enabled)
                return;

            if (m_target == null)
            {
                Debug.LogWarning("target not assigned, disabling LookAtComponent");
                m_enabled = false;
                return;
            }

            TargetRotate(m_target.position, speed);
        }
    }
}