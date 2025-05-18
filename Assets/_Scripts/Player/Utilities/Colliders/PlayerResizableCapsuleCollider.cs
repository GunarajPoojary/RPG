using UnityEngine;

namespace RPG
{
    public class PlayerResizableCapsuleCollider : ResizableCapsuleCollider
    {
        [field: SerializeField, Tooltip("Data holding configuration and runtime info for the player's ground check trigger collider.")]
        
        public PlayerTriggerColliderData TriggerColliderData { get; private set; }

        protected override void OnInit()
        {
            base.OnInit();

            TriggerColliderData.Init();
        }
    }
}