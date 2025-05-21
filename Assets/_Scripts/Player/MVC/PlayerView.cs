using UnityEngine;

namespace RPG
{
    [SelectionBase]
    [RequireComponent(typeof(PlayerInputHandler), typeof(PlayerResizableCapsuleCollider))]
    public class PlayerView : MonoBehaviour //, ISaveable
    {
        public Rigidbody Rigidbody { get; private set; }
        public Animator Animator { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }
        public PlayerResizableCapsuleCollider ResizableCapsuleCollider { get; private set; }
        private PlayerMovementController _controller;

        private void Awake()
        {
            Animator = GetComponentInChildren<Animator>();
            Rigidbody = GetComponent<Rigidbody>();
            InputHandler = GetComponent<PlayerInputHandler>();
            ResizableCapsuleCollider = GetComponent<PlayerResizableCapsuleCollider>();
        }

        private void Update()
        {
            _controller?.HandleInput();
            _controller?.Update();
        }

        private void FixedUpdate() => _controller?.FixedUpdate();

        private void OnTriggerEnter(Collider other) => _controller?.OnTriggerEnter(other);
        private void OnTriggerExit(Collider other) => _controller?.OnTriggerExit(other);

        public void SetController(PlayerMovementController controller)
        {
            _controller = controller;
            if (_controller == null)
            {
                Debug.LogError("PlayerController is null");
                return;
            }
        }

        // Animation event relays
        public void OnMovementStateAnimationEnterEvent() => _controller.OnMovementStateAnimationEnterEvent();
        public void OnMovementStateAnimationExitEvent() => _controller.OnMovementStateAnimationExitEvent();
        public void OnMovementStateAnimationTransitionEvent() => _controller.OnMovementStateAnimationTransitionEvent();
    }
}