using UnityEngine;

namespace RPG
{
    public interface IPlayerService
    {
        // Define methods and properties for player service
    }

    public class PlayerService
    {
        public PlayerController PlayerController { get; private set; }

        public PlayerService(PlayerStateModel model, PlayerView view)
        {
            PlayerController = new PlayerController(view);
            PlayerController.InitPlayerStateMachine(model);
        }
    }
}