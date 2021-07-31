using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Components.UI
{
    public class FadeOutComponent : MonoBehaviour
    {
        [SerializeField] private CanvasGroup group;
        
        public IEnumerator FadeOut(float speed)
        {
            for (float ft = 1f; ft > 0; Mathf.Clamp(ft -= speed, 0, 1))
            {
                @group.alpha = ft;
                yield return new WaitForSeconds(.1f);
            }
        }

        public static UnityAction fadeOutSignal;
        public IEnumerator FadeIn(float speed)
        {
            for (float ft = 0f; ft < 1; Mathf.Clamp(ft += speed, 0, 1))
            {
                @group.alpha = ft;
                yield return new WaitForSeconds(0.1f);
            }
            fadeOutSignal.Invoke();
        }

        private void Start()
        {
            StartCoroutine(FadeOut(0.1f));
        }
    }
}