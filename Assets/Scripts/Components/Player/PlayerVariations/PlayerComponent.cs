using System;
using Interfaces.Player;
using Managers.Player;
using UnityEngine;

namespace Components.Player.PlayerVariations
{
    public class PlayerComponent : MonoBehaviour, IPlayer
    {
        private Transform m_transform;
        private ILook m_look;
        private IMovement m_movement;
        private IInteract m_interact;

        private void Init()
        {
            m_look ??= GetComponent<ILook>();
            m_movement ??= GetComponent<IMovement>();
            m_interact ??= GetComponent<IInteract>();
            m_transform ??= transform;
            
            PlayerManager.setEnableMovement = m_movement.SetEnabled;
            PlayerManager.setEnableLook = m_look.SetEnabled;
            PlayerManager.setEnableInteract = m_interact.SetEnabled;
            PlayerManager.setWalkSpeed = m_movement.SetWalkSpeed;
            PlayerManager.walkSpeed = m_movement.WalkSpeed;
            PlayerManager.defaultWalkSpeed = m_movement.DefaultWalkSpeed;
            PlayerManager.setPlayerPosition = SetPosition;
            PlayerManager.setPlayerRotation = SetRotation;
        }
        
        private void SetPosition(Vector3 position)
        {
            m_transform.position = position;
        }

        private void SetRotation(Quaternion rotation)
        {
            m_look.Camera().transform.rotation = rotation;
        }

        private void Start()
        {
            PlayerManager.OnPlayerSpawn();
        }

        private void Awake()
        {
            Init();
        }

        public Transform Transform()
        {
            return m_transform;
        }

        public ILook LookComponent()
        {
            if (m_look is null)
                Init();
            return m_look;
        }

        public IMovement MovementComponent()
        {
            if (m_look is null)
                Init();
            return m_movement;
        }

        public IInteract InteractComponent()
        {
            if (m_interact is null)
                Init();
            return m_interact;
        }
    }
}