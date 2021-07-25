using Components.GameObjects;
using UnityEngine;

namespace Managers.Player
{
    public class InteractManager : MonoBehaviour
    {
        public string actionButton = "Fire1";

        public Camera playerCamera;
        private void Update()
        {
            var ray = playerCamera.ViewportPointToRay(Vector3.one / 2f);
            if (!Physics.Raycast(ray, out var hitInfo, 2f))
                return;

            var hitItem = hitInfo.collider.GetComponent<InteractableObject>();
            if (hitItem is null)
                return;

            if (!hitItem.CanInteract())
                return;
            
            //TODO: Вызвать сигнал для отображения "интерактивности" предмета.

            var interactButton = Input.GetButtonDown(actionButton);
            if (!interactButton)
                return;

            hitItem.Interact();
        }
    }
}
