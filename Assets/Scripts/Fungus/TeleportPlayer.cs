using Managers.Player;
using UnityEngine;

namespace Fungus
{
    [CommandInfo("Player", "Teleport Player", "Change camera position to transform")]
    public class TeleportPlayer : Command
    {
        [SerializeField] private Transform newPosition;
        [SerializeField] private bool changeRotation = true;
        
        public override void OnEnter()
        {

            PlayerManager.SetPlayerPosition(newPosition.position);
            
            if (changeRotation)
                PlayerManager.SetPlayerRotation(newPosition.rotation);
            
            Continue();
        }
        
        public override string GetSummary()
        {
            return $"'reposition point = {newPosition}, rotate = {changeRotation}'";
        }
        
        public override Color GetButtonColor()
        {
            return new Color32(255, 181, 33, 255);
        }
    }
}