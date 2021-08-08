namespace Managers.Player
{
    public interface IMovement
    {
        public bool Enabled();
        public void SetEnabled(bool enabled);
    }
}