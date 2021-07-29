using Components.GameObjects;
using Components.UI;
using UnityEngine;

namespace Managers.Player
{
    public class InteractManager : MonoBehaviour
    {
        private bool m_isActive = false;

        private void SetActiveUI(bool state)
        {
            if (state == m_isActive)
                return;
            m_isActive = state;
            
            
            
            InteractImage.ShowAction().Invoke(m_isActive);
        }
        
        public string actionButton = "Fire1";

        public Camera playerCamera;

        private InteractableObject m_interactableObject;

        private bool IsInteractableItem()
        {
            var ray = playerCamera.ViewportPointToRay(Vector3.one / 2f);
            if (!Physics.Raycast(ray, out var hitInfo, 2f))
                return false;
            var hitItem = hitInfo.collider.GetComponent<InteractableObject>();
            if (hitItem is null)
                return false;
            if (!hitItem.CanInteract())
                return false;

            m_interactableObject = hitItem;

            return true;
        }

        private void Interact()
        {
            var interactButton = Input.GetButtonDown(actionButton);
            if (!interactButton)
                return;

            m_interactableObject.Interact();
        }
        
        private void Update()
        {
            if (!IsInteractableItem())
            {
                SetActiveUI(false);
                return;
            }
            SetActiveUI(true);
            Interact();
        }
    }
}
