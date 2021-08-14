using Interfaces.Player;
using UnityEngine;

namespace Components.Player
{
    public class PlayerComponent : MonoBehaviour, IPlayer
    {
        public ILook LookComponent()
        {
            return GetComponent<ILook>();
        }

        public IMovement MovementComponent()
        {
            return GetComponent<IMovement>();
        }
    }
}