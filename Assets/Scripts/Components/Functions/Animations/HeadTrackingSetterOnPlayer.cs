using System;
using System.Collections.Generic;
using Components.Animation;
using Components.Player;
using Components.Player.PlayerVariations;
using Managers.Player;
using UnityEngine;

namespace Components.Functions.Animations
{
    public class HeadTrackingSetterOnPlayer : MonoBehaviour
    {
        public List<HeadTracking> headTracks;

        private void SetTarget()
        {
            var target = PlayerManager.Player().Transform();
            foreach (var track in headTracks)
            {
                track.SetTracking(target);
            }
        }

        private void Awake()
        {
            PlayerManager.onPlayerSpawn -= SetTarget;
            PlayerManager.onPlayerSpawn += SetTarget;
        }
    }
}