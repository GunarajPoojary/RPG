using UnityEngine;

namespace RPG
{
    /// <summary>
    /// Holds configuration data for the player's state machine, including grounded and airborne states.
    /// </summary>
    [CreateAssetMenu(fileName = "PlayerStateMachineDataSO", menuName = "Custom/Characters/Player/StateMachine/Data")]
    public class PlayerStateMachineDataSO : ScriptableObject
    {
        [field: SerializeField] public PlayerGroundedData GroundedData { get; private set; }
        [field: SerializeField] public PlayerAirborneData AirborneData { get; private set; }
    }
}