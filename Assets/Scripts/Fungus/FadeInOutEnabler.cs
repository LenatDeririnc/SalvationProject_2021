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
    
    [CommandInfo("Cutscene", "Fade In/Out Enabler", "Enable/Disable Fade In/Out")]
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
    }
}