using System;
using Components.Player;
using Interfaces.Player;
using Managers.Player;
using Managers.Player.CameraRotateBehaviours;
using UnityEngine;

namespace Components.GameObjects
{
    public class LookAtEnabler : MonoBehaviour
    {
        private ILook m_playerLook;
        public Transform target;
        public float speed = 1;

        private void SetPlayerCollider(Collider player) => m_playerLook = player.GetComponent<ILook>();

        public void Enable()
        {
            m_playerLook ??= PlayerManager.player.LookComponent();
            m_playerLook.SetLookBehaviour(new TargetRotate(m_playerLook.Camera(), target, speed));
        }

        public void Disable()
        {
            m_playerLook ??= PlayerManager.player.LookComponent();
            m_playerLook.SetLookBehaviour(new InputRotate(m_playerLook.Camera()));
        }
    }
}