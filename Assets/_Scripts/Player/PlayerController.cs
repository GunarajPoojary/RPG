using UnityEngine;

namespace RPG
{
    public interface IMovementStateAnimationHandler
    {
        Animator Animator { get; }

        void OnMovementStateAnimationEnterEvent();
        void OnMovementStateAnimationExitEvent();
        void OnMovementStateAnimationTransitionEvent();
    }

    [SelectionBase]
    [RequireComponent(typeof(PlayerInputHandler))]
    [RequireComponent(typeof(PlayerResizableCapsuleCollider))]
    public class PlayerController : MonoBehaviour, IMovementStateAnimationHandler//, ISaveable
    {
        [field: Header("References")]
        [field: SerializeField] public PlayerStateMachineDataSO Data { get; private set; }

        [field: Header("Collisions")]
        [field: SerializeField] public PlayerLayerData LayerData { get; private set; }

        [field: Header("Animations")]
        [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

        public Rigidbody Rigidbody { get; private set; }
        public Animator Animator { get; private set; }

        public PlayerInputHandler Input { get; private set; }
        public PlayerResizableCapsuleCollider ResizableCapsuleCollider { get; private set; }

        public Transform MainCameraTransform { get; private set; }

        private PlayerStateFactory _stateFactory;

        private void Awake()
        {
            AnimationData.Init();

            Rigidbody = GetComponent<Rigidbody>();
            Animator = GetComponentInChildren<Animator>();

            Input = GetComponent<PlayerInputHandler>();
            ResizableCapsuleCollider = GetComponent<PlayerResizableCapsuleCollider>();

            MainCameraTransform = Camera.main.transform;

            _stateFactory = new PlayerStateFactory(this);
        }

        private void Start() => _stateFactory.SwitchState(_stateFactory.IdleState);

        private void Update()
        {
            _stateFactory.HandleInput();
            _stateFactory.Update();
        }

        private void FixedUpdate() => _stateFactory.PhysicsUpdate();

        private void OnTriggerEnter(Collider collider) => _stateFactory.OnTriggerEnter(collider);

        private void OnTriggerExit(Collider collider) => _stateFactory.OnTriggerExit(collider);

        public void OnMovementStateAnimationEnterEvent() => _stateFactory.OnAnimationEnterEvent();

        public void OnMovementStateAnimationExitEvent() => _stateFactory.OnAnimationExitEvent();

        public void OnMovementStateAnimationTransitionEvent() => _stateFactory.OnAnimationTransitionEvent();

        // #region ISaveable Methods
        // public void LoadData(GameData data)
        // {
        //     Rigidbody.position = data.Position;
        //     Rigidbody.rotation = data.Rotation;
        // }
        //
        // public void SaveData(GameData data)
        // {
        //     data.Position = Rigidbody.position;
        //     data.Rotation = Rigidbody.rotation;
        // }
        // #endregion
    }
}