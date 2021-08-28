using System.Collections.Generic;
using Components.Animation;
using Managers.Player;
using UnityEngine;

namespace Components.Functions.Animations
{
    public class HeadTrackingSetterOnCamera : MonoBehaviour
    {
        public List<HeadTracking> headTracks;

        private void SetTarget()
        {
            var target = PlayerManager.GameCamera().Transform();
            foreach (var track in headTracks)
            {
                track.SetTracking(target);
            }
        }

        private void Awake()
        {
            PlayerManager.onCameraSpawn -= SetTarget;
            PlayerManager.onCameraSpawn += SetTarget;
        }
    }
}