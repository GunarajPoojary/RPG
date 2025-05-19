using UnityEngine;

namespace RPG 
{
    [SelectionBase]
    [RequireComponent(typeof(PlayerInputHandler), typeof(PlayerResizableCapsuleCollider))]
    public class PlayerController : MonoBehaviour, IMovementStateAnimationHandler //, ISaveable
    {
        [field: Header("References")]
        [field: SerializeField] public PlayerStateMachineDataSO Data { get; private set; }

        [field: Header("Collisions")]
        [field: SerializeField] public PlayerLayerData LayerData { get; private set; }

        [field: Header("Animations")]
        [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

        public Rigidbody Rigidbody { get; private set; }

        public Animator Animator { get; private set; }

        // Interfaces for player input actions (Move, Run, Jump)
        public IMoveInput MoveInput { get; private set; }
        public IRunInput RunInput { get; private set; }
        public IJumpInput JumpInput { get; private set; }

        public PlayerResizableCapsuleCollider ResizableCapsuleCollider { get; private set; }

        public Transform MainCameraTransform { get; private set; }

        private PlayerStateFactory _stateFactory;

        private void Awake()
        {
            AnimationData.Init(); 

            Rigidbody = GetComponent<Rigidbody>(); 
            Animator = GetComponentInChildren<Animator>(); 

            MoveInput = GetComponent<IMoveInput>();
            RunInput = GetComponent<IRunInput>();
            JumpInput = GetComponent<IJumpInput>();

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

        #region IMovementStateAnimationHandler Methods
        public void OnMovementStateAnimationEnterEvent() => _stateFactory.OnAnimationEnterEvent();

        public void OnMovementStateAnimationExitEvent() => _stateFactory.OnAnimationExitEvent();

        public void OnMovementStateAnimationTransitionEvent() => _stateFactory.OnAnimationTransitionEvent();
        #endregion

        /*
        #region ISaveable Methods
        // Loads the player's saved position and rotation
        public void LoadData(GameData data)
        {
            Rigidbody.position = data.Position;
            Rigidbody.rotation = data.Rotation;
        }

        // Saves the player's current position and rotation to GameData
        public void SaveData(GameData data)
        {
            data.Position = Rigidbody.position;
            data.Rotation = Rigidbody.rotation;
        }
        #endregion
        */
    }
}