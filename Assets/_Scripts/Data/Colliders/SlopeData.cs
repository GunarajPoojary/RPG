using UnityEngine;

namespace RPG
{
    /// <summary>
    /// Contains configuration values for handling slope movement and step climbing behavior.
    /// Includes parameters for step height, raycast distance, and force applied when stepping up.
    /// </summary>
    [System.Serializable]
    public class SlopeData
    {
        [field: SerializeField][field: Range(0f, 1f)] public float StepHeightPercentage { get; private set; } = 0.25f;
        [field: SerializeField][field: Range(0f, 5f)] public float FloatRayDistance { get; private set; } = 2f;
        [field: SerializeField][field: Range(0f, 50f)] public float StepReachForce { get; private set; } = 25f;
    }
}