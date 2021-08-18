using System;
using Interfaces.Player;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Components.Player
{
    public class PlayerComponent : MonoBehaviour, IPlayer
    {
        private ILook m_look;
        private IMovement m_movement;
        private IInteract m_interact;

        private void Init()
        {
            m_look ??= GetComponent<ILook>();
            m_movement ??= GetComponent<IMovement>();
            m_interact ??= GetComponent<IInteract>();
        }

        private void Awake()
        {
            Init();
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