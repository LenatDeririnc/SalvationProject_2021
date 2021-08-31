using System;
using System.Collections;
using Managers.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Components.UI
{
    public class FadeOutComponent : MonoBehaviour
    {
        [SerializeField] private CanvasGroup group;

        private void Start()
        {
            SetCanvasGroup(@group);
        }

        public void SetCanvasGroup(CanvasGroup group)
        {
            FadeInOutManager.SetcanvasGroup(group);
        }

        public void FadeIn(float speed)
        {
            FadeInOutManager.FadeIn(this, speed);
        }

        public void FadeOut(float speed)
        {
            FadeInOutManager.FadeOut(this, speed);
        }
    }
}