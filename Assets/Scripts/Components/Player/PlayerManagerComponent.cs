using Interfaces.Player;
using Managers.Player;
using UnityEngine;

namespace Components.Player
{
    public class PlayerManagerComponent : MonoBehaviour
    {
        private IPlayer m_player;

        private IPlayer Player => m_player ??= PlayerManager.player;
        
        void SetMoveEnabled(bool state)
        {
            Player.MovementComponent().SetEnabled(state);
        }

        void SetLookEnabled(bool state)
        {
            Player.LookComponent().SetEnabled(state);
        }
    }
}