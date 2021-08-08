using System;
using UnityEngine;

namespace Components.Player
{
    public class CursorComponent : MonoBehaviour
    {
        [SerializeField] private bool m_cursorLocked = true;

        public bool CursorLocked
        {
            get => m_cursorLocked;
            set
            {
                if (m_cursorLocked == value)
                    return;

                m_cursorLocked = value;
                UpdateCursorState();
            }
        }

        private void UpdateCursorState()
        {
            Cursor.visible = !m_cursorLocked;
            Cursor.lockState = m_cursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
        }

        private void Start()
        {
            UpdateCursorState();
        }

#if UNITY_EDITOR
        private void FixedUpdate()
        {
            UpdateCursorState();
        }
#endif
    }
}