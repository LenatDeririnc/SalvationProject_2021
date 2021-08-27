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
        public static Action<bool> setEnableMovement;
        public static Action<bool> setEnableLook;
        public static Action<bool> setEnableInteract;
        public static Action<float> setWalkSpeed;
        public delegate float FloatAction();
        
        public static FloatAction walkSpeed;
        public static FloatAction defaultWalkSpeed;

        private void Init()
        {
            m_look ??= GetComponent<ILook>();
            m_movement ??= GetComponent<IMovement>();
            m_interact ??= GetComponent<IInteract>();
            m_transform ??= transform;
            
            setEnableMovement = m_movement.SetEnabled;
            setEnableLook = m_look.SetEnabled;
            setEnableInteract = m_interact.SetEnabled;
            setWalkSpeed = m_movement.SetWalkSpeed;
            walkSpeed = m_movement.WalkSpeed;
            defaultWalkSpeed = m_movement.DefaultWalkSpeed;
        }

        private void Start()
        {
            if (onPlayerSpawn != null)
                onPlayerSpawn.Invoke();
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