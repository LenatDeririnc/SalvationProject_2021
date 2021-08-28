using System;
using Managers.UI;
using UnityEngine;

namespace Fungus
{

    [CommandInfo("Cutscene", "Fade Enabler by time", "Enable Fade")]
    public class FadeInOutEnablerV2 : Command
    {
        public FadeType fadeType;
        public float time;
        
        public void FadeIn(float time)
        {
            var speed = 0.1f / time;
            FadeInOutManager.FadeIn(this, speed);
        }

        public void FadeOut(float time)
        {
            var speed = 0.1f / time;
            FadeInOutManager.FadeOut(this, speed);
        }

        public override void OnEnter()
        {
            switch (fadeType)
            {
                case FadeType.In:
                    FadeIn(time);
                    break;
                case FadeType.Out:
                    FadeOut(time);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            Continue();
        }
        
        public override string GetSummary()
        {
            return $"'Fade{fadeType}' => time: {time}";
        }
        
        public override Color GetButtonColor()
        {
            return new Color32(255, 181, 33, 255);
        }
    }
}