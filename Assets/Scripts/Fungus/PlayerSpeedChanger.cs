using System;
using Managers.Player;
using UnityEngine;

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
        
        public override string GetSummary()
        {
            switch (actionType)
            {
                case PlayerSpeedActionType.SetSpeed:
                    return $"'New speed = {speed}'";
                case PlayerSpeedActionType.SetDefaultSpeed:
                    return $"'New speed = default'";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        public override Color GetButtonColor()
        {
            return new Color32(255, 181, 33, 255);
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