using System;
using Interfaces.Player;
using Managers.Player;
using UnityEngine;

namespace Components.Player.PlayerVariations
{
    public class PlayerAsStaticCamera : MonoBehaviour, IPlayer
    {
        private Transform m_transform;
        private ILook m_look;
        private IMovement m_movement;
        // private IInteract m_interact;
        
        private void Init()
        {
            m_transform ??= transform;
            m_look ??= GetComponent<ILook>();
            m_movement ??= GetComponent<IMovement>();
            
            PlayerManager.SwitchView(Views.GameCameraView);
            PlayerManager.SetGameCamera(this);
            // m_interact ??= GetComponent<IInteract>();
        }

        private void Awake()
        {
            Init();
        }

        public Transform Transform()
        {
            return transform;
        }

        public ILook LookComponent()
        {
            throw new System.NotImplementedException();
        }

        public IMovement MovementComponent()
        {
            throw new System.NotImplementedException();
        }

        public IInteract InteractComponent()
        {
            throw new System.NotImplementedException();
        }
    }
}