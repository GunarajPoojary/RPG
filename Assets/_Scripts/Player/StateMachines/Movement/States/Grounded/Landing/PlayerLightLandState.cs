using UnityEngine; 

namespace RPG 
{
    // Represents the light landing state — when the player lands softly after a fall or jump
    public class PlayerLightLandState : PlayerGroundedState
    {
        public PlayerLightLandState(PlayerStateFactory playerStateFactory) : base(playerStateFactory) { }

        #region IState Methods
        public override void Enter()
        {
            base.Enter();

            // Set jump force to stationary value (typically for idle jump after landing)
            _stateFactory.ReusableData.CurrentJumpForce = _airborneData.JumpData.StationaryForce;

            _stateFactory.PlayerController.JumpInput.JumpAction.Disable();

            ResetVelocity();
        }

        public override void Exit()
        {
            base.Exit();

            // After exit, determine if player should transition to idle, walk, or run
            OnLandToMovingState();
        }

        public override void Update()
        {
            base.Update(); 

            if (_stateFactory.ReusableData.MovementInput == Vector2.zero)
                return;

            // If movement input is detected, transition to walk/run
            OnMove();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            if (!IsMovingHorizontally())
                return;

            ResetVelocity();
        }

        public override void OnAnimationTransitionEvent() => _stateFactory.SwitchState(_stateFactory.IdleState);
        #endregion
    }
}