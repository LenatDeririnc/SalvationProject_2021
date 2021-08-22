using System;
using Components.Player;
using UnityEngine;

namespace Components.Functions
{
    public class PlayerControlEnabler : MonoBehaviour
    {
        public void SetEnableMovement(bool enable)
        {
            PlayerComponent.setEnableMovement.Invoke(enable);
        }

        public void SetEnableLook(bool enable)
        {
            PlayerComponent.setEnableLook.Invoke(enable);
        }

        public void SetEnableInteract(bool enable)
        {
            PlayerComponent.setEnableInteract.Invoke(enable);
        }

        public void SetEnabled(bool enable)
        {
            PlayerComponent.setEnableLook.Invoke(enable);
            PlayerComponent.setEnableMovement.Invoke(enable);
            PlayerComponent.setEnableInteract.Invoke(enable);
        }
    }
}