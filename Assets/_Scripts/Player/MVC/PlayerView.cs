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
        private PlayerController _controller;

        private void Awake()
        {
            Animator = GetComponentInChildren<Animator>();
            Rigidbody = GetComponent<Rigidbody>();
            InputHandler = GetComponent<PlayerInputHandler>();
            ResizableCapsuleCollider = GetComponent<PlayerResizableCapsuleCollider>();
        }

        private void Update()
        {
            _controller?.PlayerMovementStateMachine.HandleInput();
            _controller?.PlayerMovementStateMachine.Update();
        }

        private void FixedUpdate() => _controller?.PlayerMovementStateMachine.FixedUpdate();

        private void OnTriggerEnter(Collider other) => _controller?.PlayerMovementStateMachine.OnTriggerEnter(other);
        private void OnTriggerExit(Collider other) => _controller?.PlayerMovementStateMachine.OnTriggerExit(other);

        public void SetController(PlayerController controller) => _controller = controller;

        // Animation event relays
        public void OnMovementStateAnimationEnterEvent() => _controller?.PlayerMovementStateMachine.OnMovementStateAnimationEnterEvent();
        public void OnMovementStateAnimationExitEvent() => _controller?.PlayerMovementStateMachine.OnMovementStateAnimationExitEvent();
        public void OnMovementStateAnimationTransitionEvent() => _controller?.PlayerMovementStateMachine.OnMovementStateAnimationTransitionEvent();
    }
}