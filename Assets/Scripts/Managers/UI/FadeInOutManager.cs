using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Managers.UI
{
    public class FadeInOutManager
    {
        private static CanvasGroup group;
        private static MonoBehaviour lastReference;
        private static Coroutine currentCoroutine;

        public static void Clear()
        {
            FadeInOutManager.fadeOutSignal = null;
            FadeInOutManager.fadeInSignal = null;
            currentCoroutine = null;
        }

        public static void SetcanvasGroup(CanvasGroup @group)
        {
            FadeInOutManager.@group = group;
        }

        public static UnityAction fadeInSignal;
        public static void FadeIn(MonoBehaviour reference, float speed)
        {
            if (currentCoroutine != null)
            {
                lastReference.StopCoroutine(currentCoroutine);
            }
            
            lastReference = reference;

            currentCoroutine = lastReference.StartCoroutine(FadeInCoroutine(speed));
        }
        
        public static UnityAction fadeOutSignal;
        public static void FadeOut(MonoBehaviour reference, float speed)
        {
            if (currentCoroutine != null)
            {
                lastReference.StopCoroutine(currentCoroutine);
            }

            lastReference = reference;

            currentCoroutine = lastReference.StartCoroutine(FadeOutCoroutine(speed));
        }
        
        public static IEnumerator FadeOutCoroutine(float speed)
        {
            float ft;
            for (ft = 1f; ft > 0; Mathf.Clamp(ft -= speed, 0, 1))
            {
                @group.alpha = ft;
                yield return new WaitForSeconds(0.1f);
            }
            
            @group.alpha = ft;
            FadeInOutManager.fadeOutSignal?.Invoke();
        }
        
        public static IEnumerator FadeInCoroutine(float speed)
        {
            float ft;
            for (ft = 0f; ft < 1; Mathf.Clamp(ft += speed, 0, 1))
            {
                @group.alpha = ft;
                yield return new WaitForSeconds(0.1f);
            }

            @group.alpha = ft;
            FadeInOutManager.fadeInSignal?.Invoke();
        }                            
    }
}