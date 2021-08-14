namespace Interfaces.Player
{
    public interface IPlayer
    {
        ILook LookComponent();
        IMovement MovementComponent();
        IInteract InteractComponent();
    }
}