using UnityEngine;
using UnityEngine.InputSystem;

namespace RPG
{
    /// <summary>
    /// Handles third-person camera rotation by updating the Cinemachine target's orientation based on player look input.
    /// </summary>
    public class ThirdPersonFollowCamera : MonoBehaviour
    {
        [Space(10), Tooltip("Data that holds camera clamp limits and the camera's target transform.")]
        [SerializeField] private PlayerCameraData _playerCameraData;

        private ILookInput _playerInput;

        private float _cinemachineTargetYaw;
        private float _cinemachineTargetPitch;

        // Small threshold to ignore minimal input changes
        private const float THRESHOLD = 0.01f;

        private Vector2 _look;

        private void Awake() => _playerInput = GetComponentInParent<ILookInput>();

        private void OnEnable()
        {
            _playerInput.LookAction.performed += OnLook;
            _playerInput.LookAction.canceled += OnLook;
        }

        private void OnDisable()
        {
            _playerInput.LookAction.performed -= OnLook;
            _playerInput.LookAction.canceled -= OnLook;
        }

        private void Start() => _cinemachineTargetYaw = _playerCameraData.CinemachineTrackingTarget.rotation.eulerAngles.y;

        private void LateUpdate() => UpdateCameraRotation();

        private void OnLook(InputAction.CallbackContext ctx) => _look = ctx.ReadValue<Vector2>();

        // Applies camera rotation based on input and clamps the rotation values
        private void UpdateCameraRotation()
        {
            // Only update if there's meaningful input
            if (_look.sqrMagnitude >= THRESHOLD)
            {
                _cinemachineTargetYaw += _look.x;
                _cinemachineTargetPitch += _look.y;
            }

            // Clamp the angles to keep pitch within desired limits
            _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
            _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, _playerCameraData.BottomClamp, _playerCameraData.TopClamp);

            // Apply the rotation to the camera target
            _playerCameraData.CinemachineTrackingTarget.rotation = Quaternion.Euler(_cinemachineTargetPitch, _cinemachineTargetYaw, 0f);
        }

        // Clamps angle between min and max, correcting overflow
        private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
        {
            if (lfAngle < -360f) lfAngle += 360f;
            if (lfAngle > 360f) lfAngle -= 360f;

            return Mathf.Clamp(lfAngle, lfMin, lfMax);
        }
    }
}