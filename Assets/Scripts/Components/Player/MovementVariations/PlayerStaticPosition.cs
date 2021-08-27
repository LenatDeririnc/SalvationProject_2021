using Interfaces.Player;
using UnityEngine;

namespace Components.Player.MovementVariations
{
    public class PlayerStaticPosition : MonoBehaviour, IMovement
    {
        public bool Enabled() => true;

        public void SetEnabled(bool state)
        {
            Debug.LogWarning("can't unset movement of static camera");
        }

        public float WalkSpeed()
        {
            return 0;
        }

        public float DefaultWalkSpeed()
        {
            return 0;
        }

        public void SetWalkSpeed(float speed)
        {
            Debug.LogWarning("can't set walkspeed to static movement behaviour");
        }
    }
}