using Managers.UI;
using UnityEngine;

namespace Fungus
{
    [CommandInfo("Cutscene", "Set Fade", "Set Fade")]
    public class SetFadeIn : Command
    {
        [SerializeField] private float value;
        
        public override void OnEnter()
        {
            FadeInOutManager.SetFade(value);
            
            Continue();
        }
        
        public override string GetSummary()
        {
            return $"'Fade = {value}";
        }
        
        public override Color GetButtonColor()
        {
            return new Color32(255, 181, 33, 255);
        }
    }
}