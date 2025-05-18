using UnityEngine;

namespace RPG
{
    /// <summary>
    /// Stores configuration and calculated data for the player's ground check trigger collider.
    /// Used for detecting ground contact by tracking the vertical extents of the assigned BoxCollider.
    /// </summary>
    [System.Serializable]
    public class PlayerTriggerColliderData
    {
        [field: SerializeField] public BoxCollider GroundCheckCollider { get; private set; }

        public Vector3 GroundCheckColliderVerticalExtents { get; private set; }

        public void Init() => GroundCheckColliderVerticalExtents = GroundCheckCollider.bounds.extents;
    }
}