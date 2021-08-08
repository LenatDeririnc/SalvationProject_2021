using System;
using Managers.Player;
using UnityEngine;

namespace Components.GameObjects
{
    [RequireComponent(typeof(TriggerObject))]
    public class LookAtEnabler : MonoBehaviour
    {
        private TriggerObject m_trigger;
        private IPlayer m_player;
        public Transform target;

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

        private void SetPlayerCollider(Collider player) => m_player = player.GetComponent<IPlayer>();

        public void Enable()
        {
            m_player.SetLookTarget(target);
        }

        public void Disable()
        {
            m_player.SetLookAtEnabled(false);
            m_player.SetLookEnabled(true);
        }
    }
}