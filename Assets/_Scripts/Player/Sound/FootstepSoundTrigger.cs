using UnityEngine;

namespace RPG
{
    /// <summary>
    /// Responsible for triggering footstep and landing sounds using animation events
    /// </summary>
    public class FootstepSoundTrigger : MonoBehaviour
    {
        [SerializeField] private BoxCollider _groundCheckCollider;

        [SerializeField] private AudioClip _landingAudioClip;

        [SerializeField] private AudioClip[] _footstepAudioClips;

        [Range(0, 1)]
        [SerializeField] private float FootstepAudioVolume = 0.5f;

        private void OnFootstep(AnimationEvent animationEvent)
        {
            if (animationEvent.animatorClipInfo.weight > 0.5f)
            {
                if (_footstepAudioClips.Length > 0)
                {
                    var index = Random.Range(0, _footstepAudioClips.Length);

                    AudioSource.PlayClipAtPoint(
                        _footstepAudioClips[index], 
                        transform.TransformPoint(_groundCheckCollider.center), 
                        FootstepAudioVolume);
                }
            }
        }

        private void OnLand(AnimationEvent animationEvent)
        {
            if (animationEvent.animatorClipInfo.weight > 0.5f)
            {
                AudioSource.PlayClipAtPoint(
                    _landingAudioClip, 
                    transform.TransformPoint(_groundCheckCollider.center), 
                    FootstepAudioVolume);
            }
        }
    }
}