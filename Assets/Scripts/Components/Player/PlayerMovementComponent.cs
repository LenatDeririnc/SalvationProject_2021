using Interfaces.Player;
using UnityEngine;

namespace Components.Player
{
    [RequireComponent(typeof(IPlayer))]
    public class PlayerMovementComponent : MonoBehaviour, IMovement
    {
        [SerializeField] private bool m_enabled = true;
        public bool Enabled() => m_enabled;
        public void SetEnabled(bool state) => m_enabled = state;
        
        public Rigidbody rb;
        public Transform getForwardFrom;
        public float forceScale;

        void Update()
        {
            if (!m_enabled)
                return;
            
            var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (input == Vector2.zero)
                return;
            
            var forward = getForwardFrom.forward;
            forward.y = 0;
            forward.Normalize();

            var right = getForwardFrom.right;
            right.y = 0;
            right.Normalize();

            forward *= input.y;
            right *= input.x;

            var movVec = forward + right;
            if (movVec.magnitude > 1)
                movVec = movVec.normalized;

            rb.AddForce(movVec * (forceScale * Time.deltaTime));
        }
    }
}