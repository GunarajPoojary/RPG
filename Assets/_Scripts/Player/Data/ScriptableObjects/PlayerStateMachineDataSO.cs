using UnityEngine;

namespace RPG
{
    [CreateAssetMenu(fileName = "PlayerStateMachineDataSO", menuName = "Custom/Characters/Player/StateMachine/Data")]
    public class PlayerStateMachineDataSO : ScriptableObject
    {
        [field: SerializeField] public PlayerGroundedData GroundedData { get; private set; }
        [field: SerializeField] public PlayerAirborneData AirborneData { get; private set; }
    }
}