using UnityEngine;

namespace Managers.Player
{
    public interface IPlayer
    {
        bool MovementEnabled();
        void SetMovementEnabled(bool enabled);
        
        bool LookEnabled();
        void SetLookEnabled(bool enabled);

        bool LookAtEnabled();
        void SetLookAtEnabled(bool enabled);
        Transform LookTarget();
        void SetLookTarget(Transform target);
    }
}
