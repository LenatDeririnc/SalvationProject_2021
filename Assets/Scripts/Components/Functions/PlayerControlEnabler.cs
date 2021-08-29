using Components.Player.PlayerVariations;
using Managers.Player;
using UnityEngine;

namespace Components.Functions
{
    public class PlayerControlEnabler : MonoBehaviour
    {
        public void SetEnableMovement(bool enable)
        {
            PlayerManager.SetEnableMovement(enable);
        }

        public void SetEnableLook(bool enable)
        {
            PlayerManager.SetEnableLook(enable);
        }

        public void SetEnableInteract(bool enable)
        {
            PlayerManager.SetEnableInteract(enable);
        }

        public void SetEnabled(bool enable)
        {
            PlayerManager.SetEnableLook(enable);
            PlayerManager.SetEnableMovement(enable);
            PlayerManager.SetEnableInteract(enable);
        }
    }
}