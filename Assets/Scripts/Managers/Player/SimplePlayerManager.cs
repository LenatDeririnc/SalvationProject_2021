using System;
using Components.Player;
using UnityEngine;

namespace Managers.Player
{
    public class SimplePlayerManager : MonoBehaviour, IPlayer
    {
        private CursorComponent cursor;

        private PlayerLookComponent playerLook;
        public bool LookEnabled() => playerLook.Enabled();

        public void SetLookEnabled(bool value)
        {
            if (value)
                lookAtComponent.SetEnabled(false);
            
            playerLook.SetEnabled(value);
        }

        private PlayerMovementComponent playerMovement;

        public bool MovementEnabled() => playerMovement.Enabled();
        public void SetMovementEnabled(bool value) => playerMovement.SetEnabled(value);

        private LookAtComponent lookAtComponent;
        public bool LookAtEnabled() => lookAtComponent.Enabled();
        public void SetLookAtEnabled(bool value)
        {
            if (value)
                playerLook.SetEnabled(false);
            
            lookAtComponent.SetEnabled(value);
        }
        public Transform LookTarget() => lookAtComponent.Target();
        public void SetLookTarget(Transform target) => lookAtComponent.SetTarget(target);

        private void Awake()
        {
            cursor ??= GetComponent<CursorComponent>();
            playerLook ??= GetComponent<PlayerLookComponent>();
            playerMovement ??= GetComponent<PlayerMovementComponent>();
            lookAtComponent ??= GetComponent<LookAtComponent>();
            
            Debug.Assert(cursor != null, "cursor component not found");
            Debug.Assert(playerLook != null, "playerLook component not found");
            Debug.Assert(playerMovement != null, "playerMovement component not found");
            Debug.Assert(lookAtComponent != null, "lookAtComponent component not found");
        }

    }
}