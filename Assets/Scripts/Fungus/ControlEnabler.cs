using System;
using Components.Player;
using MoonSharp.Interpreter.Loaders;
using UnityEngine;

namespace Fungus
{
    public enum CommandsToEnableControll
    {
        AllControls,
        MovementControll,
        LookControll,
        InteractControll
    }
    
    [CommandInfo("Player", "Control Enabler", "Enable/Disable player control")]
    public class ControlEnabler : Command
    {
        [SerializeField] private CommandsToEnableControll command = CommandsToEnableControll.AllControls;
        [SerializeField] private bool setState = false;
        
        public void SetEnableMovement(bool enable)
        {
            PlayerComponent.setEnableMovement.Invoke(enable);
        }

        public void SetEnableLook(bool enable)
        {
            PlayerComponent.setEnableLook.Invoke(enable);
        }

        public void SetEnableInteract(bool enable)
        {
            PlayerComponent.setEnableInteract.Invoke(enable);
        }

        public void SetEnabled(bool enable)
        {
            PlayerComponent.setEnableLook.Invoke(enable);
            PlayerComponent.setEnableMovement.Invoke(enable);
            PlayerComponent.setEnableInteract.Invoke(enable);
        }

        public override void OnEnter()
        {
            switch (command)
            {
                case CommandsToEnableControll.AllControls:
                    SetEnabled(setState);
                    break;
                case CommandsToEnableControll.MovementControll:
                    SetEnableMovement(setState);
                    break;
                case CommandsToEnableControll.LookControll:
                    SetEnableLook(setState);
                    break;
                case CommandsToEnableControll.InteractControll:
                    SetEnableInteract(setState);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            Continue();
        }
        
        public override string GetSummary()
        {
            return "'" + command + "' = " + setState;
        }
        
        public override Color GetButtonColor()
        {
            return new Color32(255, 181, 33, 255);
        }
    }
}