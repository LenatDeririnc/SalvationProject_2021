using UnityEngine;

namespace Managers.Player
{
    public interface ILook
    {
        public bool Enabled();
        public void SetEnabled(bool enabled);

        public Transform Camera();
    }
}