using System;
using Components.GameObjects;
using UnityEngine;

namespace Components.Player
{
    [RequireComponent(typeof(Camera))]
    public class PlayerCamera : MonoBehaviour
    {
        private Camera m_camera;
        private Transform m_transform;
        private float m_pitch;
        private float m_maxPitch = 90;

        public float MaxPitch => m_maxPitch;
        public Transform transform => m_transform;
        public float Pitch
        {
            get => m_pitch;
            set => m_pitch = Mathf.Clamp(value, -m_maxPitch, m_maxPitch);
        }

        public void Awake()
        {
            m_camera ??= GetComponent<Camera>();
            m_transform ??= m_camera.transform;
        }

    }

}