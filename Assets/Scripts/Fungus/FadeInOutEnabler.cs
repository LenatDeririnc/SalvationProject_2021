using System;
using System.Collections;
using Managers.UI;
using UnityEngine;

namespace Fungus
{
    public enum FadeType
    {
        In,
        Out
    }
    
    [CommandInfo("Cutscene", "Fade Enabler", "Enable Fade")]
    public class FadeInOutEnabler : Command
    {
        public FadeType fadeType;
        public float speed;
        
        public void FadeIn(float speed)
        {
            FadeInOutManager.FadeIn(this, speed);
        }

        public void FadeOut(float speed)
        {
            FadeInOutManager.FadeOut(this, speed);
        }

        public override void OnEnter()
        {
            switch (fadeType)
            {
                case FadeType.In:
                    FadeIn(speed);
                    break;
                case FadeType.Out:
                    FadeOut(speed);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            Continue();
        }
        
        public override string GetSummary()
        {
            return $"'Fade{fadeType}' => speed: {speed}";
        }
        
        public override Color GetButtonColor()
        {
            return new Color32(255, 181, 33, 255);
        }
    }
}