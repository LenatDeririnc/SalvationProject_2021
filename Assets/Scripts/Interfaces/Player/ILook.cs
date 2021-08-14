using Components.Player;
using Managers.Player.CameraRotateBehaviours;

namespace Interfaces.Player
{
    public interface ILook
    {
        public bool Enabled();
        public void SetEnabled(bool enabled);

        public PlayerCamera Camera();

        public CameraRotateBehaviour LookBehaviour();
        public void SetLookBehaviour(CameraRotateBehaviour value);
    }
}