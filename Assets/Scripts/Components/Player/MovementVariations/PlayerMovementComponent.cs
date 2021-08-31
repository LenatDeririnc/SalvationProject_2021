using System.Collections;
using Interfaces.Player;
using Managers.Menu;
using Managers.Player;
using UnityEngine;

namespace Components.Player.MovementVariations
{
    // public static class PlayerSFX
    // {
    //     CharacterMovement characterController;
    //
    //     [Range(0, 1)] public float stepsVolume;
    //
    //     public AudioClip[] steps;
    //
    //     [Range(0, 1)] public float gunVolume;
    //
    //     public AudioClip gunShoot;
    //
    //     public AudioSource source;
    //
    //     private void Start()
    //     {
    //         characterController = GetComponent<CharacterMovement>();
    //         source = GetComponent<AudioSource>();
    //     }
    //
    //     public void PlayStep()
    //     {
    //         float floatrand = Random.value * (steps.Length - 1);
    //         int rand = (int)floatrand;
    //
    //         source.PlayOneShot(steps[rand], stepsVolume);
    //     }
    //
    //     public void PlayShoot()
    //     {
    //         source.PlayOneShot(gunShoot, gunVolume);
    //     }
    //
    //     bool isWalkPlaying = false;
    //
    //     IEnumerator WalkSound(float seconds)
    //     {
    //         isWalkPlaying = true;
    //         PlayStep();
    //         yield return new WaitForSeconds(seconds);
    //         isWalkPlaying = false;
    //     }
    //
    //     private void PlayMovementSound()
    //     {
    //         while (isWalkPlaying)
    //             return;
    //
    //         StartCoroutine(WalkSound(0.5f));
    //     }
    //
    //     private void Update()
    //     {
    //         float offsetValue = 0.5f;
    //
    //         var hor = Mathf.Abs(Input.GetAxis("Horizontal")) >= offsetValue;
    //         var ver = Mathf.Abs(Input.GetAxis("Vertical")) >= offsetValue;
    //
    //         if ((hor || ver) && characterController.isGrounded)
    //         {
    //             PlayMovementSound();
    //         }
    //     }
    // }

    [RequireComponent(typeof(IPlayer))]
    public class PlayerMovementComponent : MonoBehaviour, IMovement
    {
        private AudioSource source;
        
        [SerializeField] private bool m_enabled = true;
        [SerializeField] private float walkStepsTime;
        [SerializeField] private float walkInputSoundOffset = 1f;
        [SerializeField] private AudioClip[] walkSteps;
        public bool Enabled() => m_enabled;
        public void SetEnabled(bool state) => m_enabled = state;
        
        public Rigidbody rb;
        public Transform getForwardFrom;
        public float forceScale;

        private float defaultForceScale;

        private float walkStepsSynthedForceScale = 1f;

        private void Awake()
        {
            source = GetComponent<AudioSource>();
            defaultForceScale = forceScale;
            walkStepsSynthedForceScale = defaultForceScale / forceScale;
        }

        private Coroutine walkCoroutine;
        
        private void PlayStep()
        {
            float floatrand = Random.value * (walkSteps.Length - 1);
            int rand = (int)floatrand;
        
            source.PlayOneShot(walkSteps[rand], source.volume);
        }
        
        private void WalkSteps()
        {
            if (walkCoroutine != null)
                return;
            
            walkStepsSynthedForceScale = defaultForceScale / forceScale;
            walkCoroutine = StartCoroutine(WalkSound(walkStepsTime * walkStepsSynthedForceScale));
        }

        private IEnumerator WalkSound(float time)
        {
            yield return new WaitForSeconds(time / 2);
            PlayStep();
            yield return new WaitForSeconds(time / 2);
            ClearCoroutine();
        }

        private void ClearCoroutine()
        {
            if (walkCoroutine == null)
                return;
            
            StopCoroutine(walkCoroutine);
            walkCoroutine = null;
        }

        void Update()
        {
            // if (PauseManager.isGamePaused)
            //     return;

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
            
            if (rb.velocity.magnitude > walkInputSoundOffset)
            {
                WalkSteps();
            }
            else
            {
                ClearCoroutine();
            }
        }

        public float WalkSpeed()
        {
            return forceScale;
        }

        public float DefaultWalkSpeed()
        {
            return defaultForceScale;
        }

        public void SetWalkSpeed(float speed)
        {
            forceScale = speed;
        }
    }
}