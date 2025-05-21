using System.Collections;
using UnityEngine;

namespace RPG
{
    public class PlayerMovementStateMachine : IMovementStateAnimationHandler
    {
        private readonly PlayerView _view;
        private readonly PlayerStateModel _model;
        private readonly PlayerStateFactory _stateFactory;

        public Animator Animator => _view?.Animator;
        public Rigidbody Rigidbody => _view?.Rigidbody;
        public PlayerResizableCapsuleCollider ResizableCapsuleCollider => _view?.ResizableCapsuleCollider;

        public IMoveInput MoveInput => _view?.InputHandler;
        public IRunInput RunInput => _view?.InputHandler;
        public IJumpInput JumpInput => _view?.InputHandler;
        
        public Transform Transform => _view?.transform;

        public PlayerAnimationData AnimationData => _model?.AnimationData;
        public PlayerLayerData LayerData => _model?.LayerData;
        public PlayerStateMachineDataSO Data => _model?.StateMachineData;
        
        public PlayerMovementStateMachine(PlayerStateModel model, PlayerView view)
        {
            _model = model;
            _view = view;
            _model.AnimationData.Init();
            _stateFactory = new PlayerStateFactory(this); // You may need to adjust factory input
            _stateFactory.SwitchState(_stateFactory.IdleState);
        }

        public void Update() => _stateFactory.Update();
        public void HandleInput() => _stateFactory.HandleInput();
        public void FixedUpdate() => _stateFactory.PhysicsUpdate();

        public void OnTriggerEnter(Collider collider) => _stateFactory.OnTriggerEnter(collider);
        public void OnTriggerExit(Collider collider) => _stateFactory.OnTriggerExit(collider);

        public void OnMovementStateAnimationEnterEvent() => _stateFactory.OnAnimationEnterEvent();
        public void OnMovementStateAnimationExitEvent() => _stateFactory.OnAnimationExitEvent();
        public void OnMovementStateAnimationTransitionEvent() => _stateFactory.OnAnimationTransitionEvent();

        public void StartCoroutine(IEnumerator enumerator) => _view.StartCoroutine(enumerator);
    }
}