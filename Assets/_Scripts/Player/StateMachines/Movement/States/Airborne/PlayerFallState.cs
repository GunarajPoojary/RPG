using UnityEngine; 

namespace RPG 
{
    /// <summary>
    /// Handles the player's falling state logic while airborne
    /// </summary>
    public class PlayerFallState : PlayerAirborneState
    {
        private Vector3 _playerPositionOnEnter; 

        public PlayerFallState(PlayerStateFactory playerStateFactory) : base(playerStateFactory) { }

        #region IState Methods
        public override void Enter()
        {
            base.Enter();

            // Play the falling animation (e.g., arms waving, falling pose)
            StartAnimation(_stateFactory.PlayerController.AnimationData.FallParameterHash);

            // Store the initial Y position to calculate fall distance later
            _playerPositionOnEnter = _stateFactory.PlayerController.Transform.position;

            ResetVerticalVelocity();
        }

        public override void Exit()
        {
            base.Exit(); 

            StopAnimation(_stateFactory.PlayerController.AnimationData.FallParameterHash);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate(); 

            // Ensure vertical speed is limited while falling
            LimitVerticalVelocity();
        }
        #endregion

        #region Main Methods
        // Restricts the player's downward falling speed
        private void LimitVerticalVelocity()
        {
            Vector3 playerVerticalVelocity = GetVerticalVelocity(); 

            // If we're falling slower than the limit, do nothing
            if (playerVerticalVelocity.y >= -_airborneData.FallData.FallSpeedLimit)
                return;

            // Calculate how much to limit the fall
            Vector3 limitedVelocityForce = new(
                0f,
                -_airborneData.FallData.FallSpeedLimit - playerVerticalVelocity.y,
                0f
            );

            // Apply force to cap fall speed
            _stateFactory.PlayerController.Rigidbody.AddForce(limitedVelocityForce, ForceMode.VelocityChange);
        }
        #endregion

        #region Reusable Methods
        protected override void OnContactWithGround(Collider collider)
        {
            // Calculate how far the player has fallen
            float fallDistance = _playerPositionOnEnter.y - _stateFactory.PlayerController.Transform.position.y;

            // If fall distance is small, do a soft landing
            if (fallDistance < _airborneData.FallData.MinimumDistanceToBeConsideredHardFall)
            {
                _stateFactory.SwitchState(_stateFactory.LightLandState);
                return;
            }

            // If no input or not running, do a hard landing (heavier impact)
            if (!_stateFactory.ReusableData.ShouldRun || _stateFactory.ReusableData.MovementInput == Vector2.zero)
            {
                _stateFactory.SwitchState(_stateFactory.HardLandState);
                return;
            }

            _stateFactory.SwitchState(_stateFactory.RollState);
        }
        #endregion
    }
}