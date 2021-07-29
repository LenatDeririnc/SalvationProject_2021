using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components.UI
{
    public class InteractImage : MonoBehaviour
    {
        private Transform m_transform;
        private static UnityAction<bool> m_showAction;
        
        [SerializeField] private Vector2 hideOffset;

        private Vector2 startPos;
        private Vector2 currentPos;

        public static UnityAction<bool> ShowAction() => m_showAction;

        private void onInteract(bool state)
        {
            if (state)
            {
                currentPos = startPos;
            }
            else
            {
                currentPos = startPos + hideOffset;
            }
        }

        private void Awake()
        {
            m_transform = transform;
            startPos = transform.position;
            m_transform.position = startPos + hideOffset;
            currentPos = m_transform.position;
        }

        private void Start()
        {
            m_showAction = null;
            m_showAction += onInteract;
            onInteract(false);
        }

        private void FixedUpdate()
        {
            m_transform.position = Vector2.Lerp(m_transform.position, currentPos, 0.1f);
        }
    }
}
