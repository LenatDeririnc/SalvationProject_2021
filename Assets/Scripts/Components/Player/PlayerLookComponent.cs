using System;
using Managers.Player;
using UnityEngine;

namespace Components.Player
{
    public class PlayerLookComponent : MonoBehaviour, ILook
    {
        [SerializeField] private bool m_enabled = true;
        public bool Enabled() => m_enabled;
        public void SetEnabled(bool enabled) => m_enabled = enabled;

        public float xsen = 1, ysen = 1;
        public float maxPitch = 89;
        
        private Transform m_cameraObject;

        public Transform Camera()
        {
            m_cameraObject ??= GetComponentInChildren<Camera>().transform;
            return m_cameraObject;
        }

        private float m_pitch = 0;

        private void Awake()
        {
            Camera();
        }

        private void AlphaRotate(Vector3 rotateVector)
        {
            var cameraRotation = m_cameraObject.localRotation.eulerAngles;
            cameraRotation = rotateVector + new Vector3(m_pitch, cameraRotation.y);
            cameraRotation.x = Mathf.Clamp(cameraRotation.x, -maxPitch, maxPitch);
            m_pitch = cameraRotation.x;
            m_cameraObject.localRotation = Quaternion.Euler(cameraRotation);
        }
        
        void Update()
        {
            if (!m_enabled)
                return;

            var mouseInput = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
            if (mouseInput == Vector3.zero)
                return;

            AlphaRotate(mouseInput);
        }
    }
}