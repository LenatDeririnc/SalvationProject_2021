namespace Interfaces.Player
{
    public interface IMovement : IEnablable
    {
        public float WalkSpeed();
        public void SetWalkSpeed(float speed);
    }
}