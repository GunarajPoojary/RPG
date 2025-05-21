using UnityEngine;

namespace RPG
{
    /// <summary>
    /// Handles animation event triggers related to movement state changes for the player
    /// </summary>
    public class PlayerAnimationEventTrigger : MonoBehaviour
    {
        private IMovementStateAnimationHandler _playerStateAnimationHandler;

        private void Start()
        {
            _playerStateAnimationHandler = GameService.Instance.PlayerService.PlayerController.PlayerMovementStateMachine;

            if (_playerStateAnimationHandler == null)
                Debug.LogError("PlayerAnimationEventTrigger requires a PlayerController component in the parent hierarchy.");
        }

        public void TriggerOnMovementStateAnimationEnterEvent()
        {
            if (IsInAnimationTransition()) return;

            _playerStateAnimationHandler.OnMovementStateAnimationEnterEvent();
        }

        public void TriggerOnMovementStateAnimationExitEvent()
        {
            if (IsInAnimationTransition()) return;

            _playerStateAnimationHandler.OnMovementStateAnimationExitEvent();
        }

        public void TriggerOnMovementStateAnimationTransitionEvent()
        {
            if (IsInAnimationTransition()) return;

            _playerStateAnimationHandler.OnMovementStateAnimationTransitionEvent();
        }

        // Utility method to check if the animator is currently transitioning between animations
        // Uses default layer index 0 unless specified otherwise
        private bool IsInAnimationTransition(int layerIndex = 0) => _playerStateAnimationHandler.Animator.IsInTransition(layerIndex);
    }
}