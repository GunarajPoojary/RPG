using UnityEngine;

namespace RPG
{
    /// <summary>
    /// Stores runtime reusable data for the player's movement.
    /// </summary>
    public class PlayerStateReusableData
    {
        public Vector2 MovementInput { get; set; }

        public float MovementSpeedModifier { get; set; } = 1f;
        public float MovementOnSlopesSpeedModifier { get; set; } = 1f;
        public float MovementDecelerationForce { get; set; } = 1f;

        public bool ShouldRun { get; set; }

        private Vector3 _currentTargetRotation;
        private Vector3 _timeToReachTargetRotation;
        private Vector3 _dampedTargetRotationCurrentVelocity;
        private Vector3 _dampedTargetRotationPassedTime;

        public ref Vector3 CurrentTargetRotation => ref _currentTargetRotation;
        public ref Vector3 TimeToReachTargetRotation => ref _timeToReachTargetRotation;
        public ref Vector3 DampedTargetRotationCurrentVelocity => ref _dampedTargetRotationCurrentVelocity;
        public ref Vector3 DampedTargetRotationPassedTime => ref _dampedTargetRotationPassedTime;

        public Vector3 CurrentJumpForce { get; set; }

        public PlayerRotationData RotationData { get; set; }
    }
}