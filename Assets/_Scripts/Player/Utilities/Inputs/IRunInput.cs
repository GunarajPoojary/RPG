using UnityEngine.InputSystem;

namespace RPG
{
    /// <summary>
    /// Interface that exposes the RunAction input
    /// </summary>
    public interface IRunInput
    {
        InputAction RunAction { get; }
    }
}