using UnityEngine; 

namespace RPG 
{
    /// <summary>
    /// Handles the common airborne (in-air) state logics of the player.
    /// </summary>
    public class PlayerAirborneState : PlayerBaseMovementState
    {
        public PlayerAirborneState(PlayerStateFactory playerStateFactory) : base(playerStateFactory) { }

        #region IState Methods
        public override void Enter()
        {
            base.Enter(); 

            StartAnimation(_stateFactory.PlayerMovementStateMachine.AnimationData.AirborneParameterHash);
        }

        public override void Exit()
        {
            base.Exit();

            StopAnimation(_stateFactory.PlayerMovementStateMachine.AnimationData.AirborneParameterHash);
        }
        #endregion

        #region Reusable Methods
        protected override void OnContactWithGround(Collider collider) => _stateFactory.SwitchState(_stateFactory.LightLandState);
        #endregion
    }
}