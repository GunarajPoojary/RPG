using UnityEngine;

namespace RPG
{
    /// <summary>
    /// Responsible for triggering footstep and landing sounds using animation events
    /// </summary>
    public class FootstepSoundTrigger : MonoBehaviour
    {
        [Range(0f, 1f)]
        [SerializeField] private float _minLandClipWieghtThreshold = 0.5f;
        
        [Range(0f, 1f)]
        [SerializeField] private float _minMoveWieghtThreshold = 0.5f;

        [SerializeField] private BoxCollider _groundCheckCollider;

        [Range(0, 1)]
        [SerializeField] private float FootstepAudioVolume = 0.5f;

        private PlayerFootStepAudioModel _footStepAudioModel;

        private void Start()
        {
            _footStepAudioModel = GameService.Instance.PlayerFootStepAudioModel;
        }

        public void OnMove(AnimationEvent animationEvent)
        {
            if (animationEvent.animatorClipInfo.weight > _minMoveWieghtThreshold)
            {
                if (_footStepAudioModel.FootstepAudioClips.Length > 0)
                {
                    var index = Random.Range(0, _footStepAudioModel.FootstepAudioClips.Length);

                    AudioSource.PlayClipAtPoint(
                        _footStepAudioModel.FootstepAudioClips[index],
                        transform.TransformPoint(_groundCheckCollider.center),
                        FootstepAudioVolume);
                }
            }
        }

        public void OnLand(AnimationEvent animationEvent)
        {
            if (animationEvent.animatorClipInfo.weight > _minLandClipWieghtThreshold)
            {
                AudioSource.PlayClipAtPoint(
                    _footStepAudioModel.LandingAudioClip,
                    transform.TransformPoint(_groundCheckCollider.center),
                    FootstepAudioVolume);
            }
        }
    }
}