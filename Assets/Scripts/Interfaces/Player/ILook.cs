using Components.Player;
using Managers.Player.CameraRotateBehaviours;

namespace Interfaces.Player
{
    public interface ILook : IEnablable
    {
        public PlayerCamera Camera();
        public CameraRotateBehaviour LookBehaviour();
        public void SetLookBehaviour(CameraRotateBehaviour value);
    }
}