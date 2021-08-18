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
        public Transform target;
        public float speed = 1;

        [SerializeField] private bool m_disableInteractOnEnable = true;
        [SerializeField] private bool m_disableMovementOnEnable = true;

        public void Enable()
        {
            var player = PlayerManager.player;
            if (m_disableInteractOnEnable)
                player.InteractComponent().SetEnabled(false);
            if (m_disableMovementOnEnable)
                player.MovementComponent().SetEnabled(false);
            player.LookComponent().SetLookBehaviour(new TargetRotate(player.LookComponent().Camera(), target, speed));
        }

        public void Disable()
        {
            var player = PlayerManager.player;
            if (m_disableInteractOnEnable)
                player.InteractComponent().SetEnabled(true);
            if (m_disableMovementOnEnable)
                player.MovementComponent().SetEnabled(true);
            player.LookComponent().SetLookBehaviour(new InputRotate(player.LookComponent().Camera()));
        }
    }
}