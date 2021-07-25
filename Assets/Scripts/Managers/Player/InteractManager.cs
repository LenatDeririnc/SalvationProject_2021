using Components;
using UnityEngine;

namespace Managers.Player
{
    public class InteractManager : MonoBehaviour
    {

        public Camera playerCamera;
        private void Update()
        {
            var interactButton = Input.GetButtonDown("Fire1");
            if (!interactButton)
                return;

            Ray ray = playerCamera.ViewportPointToRay(Vector3.one / 2f); 
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 2f))
            {
                var hitItem = hitInfo.collider.GetComponent<InteractableObject>();

                if (hitItem is null)
                    return;
                
                hitItem.Interact();
            }
        }
    }
}
