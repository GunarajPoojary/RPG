using UnityEngine.InputSystem;

namespace RPG
{
    /// <summary>
    /// Interface that exposes the JumpAction input
    /// </summary>
    public interface IJumpInput
    {
        InputAction JumpAction { get; }
    }
}