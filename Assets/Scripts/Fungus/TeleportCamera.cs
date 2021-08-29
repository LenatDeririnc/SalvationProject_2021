using Managers.Player;
using UnityEngine;

namespace Fungus
{
    [CommandInfo("Camera", "Teleport Camera", "Change camera position to transform")]
    public class TeleportCamera : Command
    {
        [SerializeField] private Transform newPosition;
        [SerializeField] private bool changeRotation = true;
        
        public override void OnEnter()
        {

            PlayerManager.SetCameraPosition(newPosition.position);
            
            if (changeRotation)
                PlayerManager.setCameraRotation(newPosition.rotation);
            
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