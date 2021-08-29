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
            FadeInOutManager.SetcanvasGroup(@group);
        }
    }
}