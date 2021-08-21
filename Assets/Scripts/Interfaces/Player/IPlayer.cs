using UnityEngine;

namespace Interfaces.Player
{
    public interface IPlayer
    {
        Transform Transform();
        ILook LookComponent();
        IMovement MovementComponent();
        IInteract InteractComponent();
    }
}