namespace Interfaces.Player
{
    public interface IMovement : IEnablable
    {
        public float WalkSpeed();
        public float DefaultWalkSpeed();
        public void SetWalkSpeed(float speed);
    }
}