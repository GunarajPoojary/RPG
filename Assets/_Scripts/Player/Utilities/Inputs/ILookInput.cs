using UnityEngine.InputSystem;

namespace RPG
{
    /// <summary>
    /// Interface that exposes the LookAction input (used by camera)
    /// </summary>
    public interface ILookInput
    {
        InputAction LookAction { get; }
    }
}