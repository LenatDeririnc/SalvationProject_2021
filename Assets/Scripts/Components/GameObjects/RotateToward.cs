using System;
using Components.Player;
using Managers.Player;
using UnityEngine;

namespace Components.GameObjects
{
    public class RotateToward : MonoBehaviour
    {
        [SerializeField] private Transform m_target;
        [SerializeField] private float m_speed = 1;
        
        private Transform m_transform;

        private void Awake()
        {
            m_transform = transform;
        }

        public void SetTarget(Transform target)
        {
            m_target = target;
        }

        public void SetTargetToPlayer()
        {
            Debug.Assert(PlayerManager.Player() != null, "can't find player in player manager");
            m_target = PlayerManager.Player().Transform();
        }

        private void FixedUpdate()
        {
            var targetPosition = m_target.position;
            var position = m_transform.position;
            
            targetPosition = new Vector3(targetPosition.x, position.y, targetPosition.z);

            Vector3 targetDirection = targetPosition - position;
            var lookRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            m_transform.rotation = Quaternion.Lerp(m_transform.rotation, lookRotation, m_speed);
        }
    }
}