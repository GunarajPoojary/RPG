using UnityEngine.InputSystem;

namespace RPG
{
    /// <summary>
    /// Interface that exposes the MoveAction input
    /// </summary>
    public interface IMoveInput
    {
        InputAction MoveAction { get; }
    }
}