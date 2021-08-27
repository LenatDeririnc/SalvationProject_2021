using System;
using Components.Player.PlayerVariations;
using Managers.Player;

namespace Fungus
{
    public enum PlayerSpeedActionType
    {
        SetSpeed,
        SetDefaultSpeed
    }
    
    [CommandInfo("Player", "Speed Changer", "Change speed of player control")]
    public class PlayerSpeedChanger : Command
    {
        public PlayerSpeedActionType actionType;
        public float speed = 2000;
        
        private void SetSpeed(float speed)
        {
            PlayerManager.SetWalkSpeed(speed);
        }

        private void SetDefaultSpeed()
        {
            var defaultWalkSpeed = PlayerManager.DefaultWalkSpeed();
            PlayerManager.SetWalkSpeed(defaultWalkSpeed);
        }

        public override void OnEnter()
        {
            switch (actionType)
            {
                case PlayerSpeedActionType.SetSpeed:
                    SetSpeed(speed);
                    break;
                case PlayerSpeedActionType.SetDefaultSpeed:
                    SetDefaultSpeed();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            Continue();
        }
    }
    
    // [CustomEditor(typeof(PlayerSpeedChanger))]
    // public class MyScriptEditor : Editor
    // {
    //     public override void OnInspectorGUI()
    //     {
    //         var PlayerSpeedChanger = target as PlayerSpeedChanger;
    //
    //         PlayerSpeedChanger.actionType = (PlayerSpeedActionType)EditorGUILayout.EnumPopup(PlayerSpeedActionType.SetSpeed);
    //
    //         if(PlayerSpeedChanger.actionType == PlayerSpeedActionType.SetSpeed)
    //             PlayerSpeedChanger.speed = EditorGUILayout.FloatField("field:", PlayerSpeedChanger.speed);
    //     }
    // }
}