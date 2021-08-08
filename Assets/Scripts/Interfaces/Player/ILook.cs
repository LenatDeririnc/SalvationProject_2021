using Components.Player;
using Fungus;
using Managers.Player.CameraRotateBehaviours;
using UnityEngine;

namespace Managers.Player
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