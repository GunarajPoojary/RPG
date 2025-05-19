using UnityEngine;

namespace RPG
{
    /// <summary>
    /// Contains data for player roll state, such as speed modifier.
    /// </summary>
    [System.Serializable]
    public class PlayerRollData
    {
        [field: SerializeField][field: Range(0f, 3f)] public float SpeedModifier { get; private set; } = 1f;
    }
}