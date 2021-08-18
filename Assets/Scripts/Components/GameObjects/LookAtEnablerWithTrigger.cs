using System;
using Interfaces.Player;
using Managers.Player;
using Managers.Player.CameraRotateBehaviours;
using TMPro.EditorUtilities;
using UnityEngine;

namespace Components.GameObjects
{
    [RequireComponent(typeof(TriggerObject))]
    public class LookAtEnablerWithTrigger : MonoBehaviour
    {
        private TriggerObject m_trigger;
        private ILook m_playerLook;
        public Transform target;
        public float speed = 1;

        private void Start()
        {
            SetTrigger();
            SetPlayerListener();
        }

        private void SetTrigger()
        {
            m_trigger = GetComponent<TriggerObject>();
            Debug.Assert(m_trigger != null, "trigger object not found");
        }

        private void SetPlayerListener()
        {
            m_trigger.SendComponent += SetPlayerCollider;
            Debug.Assert(m_trigger.SendComponent != null, "can't set player object");
        }

        private void SetPlayerCollider(Collider player) => m_playerLook = player.GetComponent<ILook>();

        public void Enable()
        {
            m_playerLook.SetLookBehaviour(new TargetRotate(m_playerLook.Camera(), target, speed));
        }

        public void Disable()
        {
            m_playerLook.SetLookBehaviour(new InputRotate(m_playerLook.Camera()));
        }
    }
}