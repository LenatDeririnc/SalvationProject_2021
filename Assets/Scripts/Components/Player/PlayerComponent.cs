using System;
using Components.Functions;
using Interfaces.Player;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Components.Player
{
    public class PlayerComponent : MonoBehaviour, IPlayer
    {
        private Transform m_transform;
        private ILook m_look;
        private IMovement m_movement;
        private IInteract m_interact;

        public static Action onPlayerSpawn;

        private void Init()
        {
            m_look ??= GetComponent<ILook>();
            m_movement ??= GetComponent<IMovement>();
            m_interact ??= GetComponent<IInteract>();
            m_transform ??= transform;
        }

        private void Awake()
        {
            Init();
            PlayerControlEnabler.onEnableMovement += m_movement.SetEnabled;
            PlayerControlEnabler.onEnableLook += m_look.SetEnabled;
            PlayerControlEnabler.onEnableInteract += m_interact.SetEnabled;
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