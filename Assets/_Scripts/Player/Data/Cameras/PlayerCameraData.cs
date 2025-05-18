using UnityEngine;

namespace RPG
{
    /// <summary>
    /// Holds configuration data for the player's camera behavior,
    /// including tracking target and vertical rotation limits.
    /// </summary>
    [System.Serializable]
    public class PlayerCameraData
    {
        [field: SerializeField] public Transform CinemachineTrackingTarget { get; private set; }
        [field: SerializeField] public float TopClamp { get; private set; } = 70.0f;
        [field: SerializeField] public float BottomClamp { get; private set; } = -30.0f;
    }
}