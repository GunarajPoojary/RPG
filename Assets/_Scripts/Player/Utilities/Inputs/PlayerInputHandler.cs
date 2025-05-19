using RPG.Player.InputActions;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RPG
{
    [DefaultExecutionOrder(-1)]
    public class PlayerInputHandler : MonoBehaviour, ILookInput, IJumpInput, IRunInput, IMoveInput
    {
        public PlayerInputActions InputActions { get; private set; }

        public PlayerInputActions.PlayerActions PlayerActions { get; private set; }

        public InputAction MoveAction { get; private set; }
        public InputAction RunAction { get; private set; }
        public InputAction JumpAction { get; private set; }
        public InputAction LookAction { get; private set; }
        public InputAction LockCursorAction { get; private set; }
        public InputAction InventoryAction { get; private set; }
        public InputAction CharacterMenuAction { get; private set; }

        [Header("Mouse Cursor Settings")]
        [SerializeField] private bool _isCursorLocked = false;

        private void Awake()
        {
            InputActions = new PlayerInputActions();

            PlayerActions = InputActions.Player;

            MoveAction = PlayerActions.Move;
            JumpAction = PlayerActions.Jump;
            RunAction = PlayerActions.Run;
            LookAction = PlayerActions.Look;
            LockCursorAction = PlayerActions.LockCursor;
            InventoryAction = PlayerActions.Inventory;
            CharacterMenuAction = PlayerActions.CharacterMenu;

            LockCursorAction.performed += OnLockCursorAction;
        }

        private void OnEnable() => InputActions.Enable();

        private void OnDisable() => InputActions.Disable();

        private void Start() => SetCursorState(_isCursorLocked);

        private void OnLockCursorAction(InputAction.CallbackContext ctx)
        {
            _isCursorLocked = !_isCursorLocked;

            SetCursorState(_isCursorLocked);
        }

        /// <summary>
        /// Temporarily disables an input action for a given number of seconds.
        /// </summary>
        public void DisableActionFor(InputAction action, float seconds) => StartCoroutine(DisableAction(action, seconds));

        // Coroutine to disable and re-enable an action after a delay
        private IEnumerator DisableAction(InputAction action, float seconds)
        {
            action.Disable();

            yield return new WaitForSeconds(seconds);

            action.Enable();
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !newState;
        }
    }
}