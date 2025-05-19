using UnityEngine;

namespace RPG
{
    /// <summary>
    /// Handles animation event triggers related to movement state changes for the player
    /// </summary>
    public class PlayerAnimationEventTrigger : MonoBehaviour
    {
        private IMovementStateAnimationHandler _playerController;

        private void Awake()
        {
            _playerController = GetComponentInParent<IMovementStateAnimationHandler>();
            if (_playerController == null)
            {
                Debug.LogError("PlayerAnimationEventTrigger requires a PlayerController component in the parent hierarchy.");
            }
            else
            {
                Debug.Log(_playerController.GetType().Name);
            }
        }


        public void TriggerOnMovementStateAnimationEnterEvent()
        {
            if (IsInAnimationTransition()) return;

            _playerController.OnMovementStateAnimationEnterEvent();
        }

        public void TriggerOnMovementStateAnimationExitEvent()
        {
            if (IsInAnimationTransition()) return;

            _playerController.OnMovementStateAnimationExitEvent();
        }

        public void TriggerOnMovementStateAnimationTransitionEvent()
        {
            if (IsInAnimationTransition()) return;

            _playerController.OnMovementStateAnimationTransitionEvent();
        }

        // Utility method to check if the animator is currently transitioning between animations
        // Uses default layer index 0 unless specified otherwise
        private bool IsInAnimationTransition(int layerIndex = 0) => _playerController.Animator.IsInTransition(layerIndex);
    }
}