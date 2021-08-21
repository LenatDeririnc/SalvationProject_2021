using System;
using System.Collections.Generic;
using Components.Animation;
using Components.Player;
using Managers.Player;
using UnityEngine;

namespace Components.Functions.Animations
{
    public class HeadTrackingSetterOnPlayer : MonoBehaviour
    {
        public List<HeadTracking> headTracks;

        private void SetTarget()
        {
            var target = PlayerManager.player.Transform();
            foreach (var track in headTracks)
            {
                track.SetTracking(target);
            }
        }

        private void Awake()
        {
            PlayerComponent.onPlayerSpawn += SetTarget;
        }
    }
}