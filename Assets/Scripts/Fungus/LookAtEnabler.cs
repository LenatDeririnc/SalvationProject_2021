using System;
using Managers.Player;
using Managers.Player.CameraRotateBehaviours;
using UnityEngine;

namespace Fungus
{
    [CommandInfo("Player", "LookAt Enabler", "Enable/Disable player lookAt")]
    public class LookAtEnabler : Command
    {
        public bool setEnabled = true;
        public Transform target;
        public float speed = 1;
        
        [SerializeField] private bool m_disableInteractOnEnable = true;
        [SerializeField] private bool m_disableMovementOnEnable = true;
        
        private void Enable()
        {
            var player = PlayerManager.Player();
            if (!player.LookComponent().Enabled())
                player.LookComponent().SetEnabled(true);
            if (m_disableInteractOnEnable)
                player.InteractComponent().SetEnabled(false);
            if (m_disableMovementOnEnable)
                player.MovementComponent().SetEnabled(false);
            player.LookComponent().SetLookBehaviour(new TargetRotate(player.LookComponent().Camera(), target, speed));
        }
        
        private void Disable()
        {
            var player = PlayerManager.Player();
            if (!player.LookComponent().Enabled())
                player.LookComponent().SetEnabled(true);
            if (m_disableInteractOnEnable)
                player.InteractComponent().SetEnabled(true);
            if (m_disableMovementOnEnable)
                player.MovementComponent().SetEnabled(true);
            player.LookComponent().SetLookBehaviour(new InputRotate(player.LookComponent().Camera()));
        }

        public override void OnEnter()
        {
            if (setEnabled)
                Enable();
            else
                Disable();
            
            Continue();
        }

        public override string GetSummary()
        {
            return $"'target' = {target}, 'enabled' = {setEnabled.ToString()}, 'InteractDisable' = {m_disableInteractOnEnable.ToString()}, 'MovementDisable' = {m_disableMovementOnEnable.ToString()}";
        }
        
        public override Color GetButtonColor()
        {
            return new Color32(255, 181, 33, 255);
        }
    }
}