using ScriptableObjects.Scenes;
using UnityEngine;

namespace Components.GameObjects
{
    public class SpawnObjectComponent : MonoBehaviour
    {
        [SerializeField] SpawnObject spawnInfo;
        private Transform m_transform;

        void Init()
        {
            m_transform = GetComponent<Transform>();
        }

        private void Start()
        {
            Init();
        }

        public Transform Transform()
        {
            if (m_transform == null)
                m_transform = GetComponent<Transform>();
        
            return m_transform;
        }
        
        public SpawnObject SpawnInfo() => spawnInfo;

        private void OnDrawGizmos()
        {
            // ReSharper disable once InconsistentNaming
            var l_transform = Transform();
            var position = l_transform.position;
            var forward = l_transform.forward;
            var right = l_transform.right;
            var playerHeight = new Vector3(0.6f, 1.6f, 0.6f);

            var lineEnd = .75f;
            
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(position, .125f);
            Gizmos.DrawWireCube(position, playerHeight);
            Gizmos.DrawRay(position, transform.forward * lineEnd);
            Gizmos.DrawRay(position + forward * lineEnd, (right - forward) * .25f);
            Gizmos.DrawRay(position + forward * lineEnd, (-right - forward) * .25f);
        }
    }
}