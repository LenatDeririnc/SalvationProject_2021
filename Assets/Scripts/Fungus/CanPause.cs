using Managers.Menu;
using UnityEngine;

namespace Fungus
{
    [CommandInfo("Game", "Can Pause", "Enable/Disable pause")]
    public class CanPause : Command
    {
        // [SerializeField] private bool canPause = false;
        //
        // public override void OnEnter()
        // {
        //     PauseManager.isCanSetPause = canPause;
        // }
        //
        // public override string GetSummary()
        // {
        //     return "can pause = " + canPause;
        // }
        //
        // public override Color GetButtonColor()
        // {
        //     return new Color32(255, 50, 50, 255);
        // }
    }
}