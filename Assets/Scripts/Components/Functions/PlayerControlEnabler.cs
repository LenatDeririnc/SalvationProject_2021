using System;
using UnityEngine;

namespace Components.Functions
{
    public class PlayerControlEnabler : MonoBehaviour
    {
        public static Action<bool> onEnableMovement;
        public static Action<bool> onEnableLook;
        public static Action<bool> onEnableInteract;

        public void SetEnableMovement(bool enable)
        {
            onEnableMovement.Invoke(enable);
        }

        public void SetEnableLook(bool enable)
        {
            onEnableLook.Invoke(enable);
        }

        public void SetEnableInteract(bool enable)
        {
            onEnableInteract.Invoke(enable);
        }

        public void SetEnabled(bool enable)
        {
            onEnableLook.Invoke(enable);
            onEnableMovement.Invoke(enable);
            onEnableInteract.Invoke(enable);
        }
    }
}