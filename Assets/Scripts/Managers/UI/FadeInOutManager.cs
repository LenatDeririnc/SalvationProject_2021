using System.Collections;
using ScriptableObjects.Scenes;
using UnityEngine;
using UnityEngine.Events;

namespace Managers.UI
{
    public static class FadeInOutManager
    {
        public static float DefaultDoorFadeInSpeed() => 0.1f;
        
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
        
        public static GameObject LoadFadeOutComponent(InitSceneData initSceneData)
        {
            FadeInOutManager.Clear();

            var fadeInOutGO = initSceneData.FadeOutObject as GameObject;
            Debug.Assert(fadeInOutGO != null, "not assigned FadeOutObject information in current InitSceneData object");

            return fadeInOutGO;
        }
    }
}