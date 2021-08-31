using System.Collections;
using UnityEngine;

namespace Components.Player
{
    public class ExitGameInfo : MonoBehaviour
    {
        [SerializeField] private CanvasGroup group;
        
        private bool ButtonDown() => Input.GetButtonDown("Cancel");

        private Coroutine showCoroutine;

        private IEnumerator Show()
        {
            @group.alpha = 1;
            yield return new WaitForSeconds(5);
            @group.alpha = 0;
        }

        public void Update()
        {
            if (!(ButtonDown()))
                return;
                
            if (showCoroutine != null)
                StopCoroutine(showCoroutine);

            showCoroutine = StartCoroutine(Show());
        }
    }
}