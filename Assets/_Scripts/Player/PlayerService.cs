using UnityEngine;

namespace RPG
{
    public interface IPlayerService
    {
        // Define methods and properties for player service
    }

    public class PlayerService
    {
        public PlayerMovementController PlayerController { get; private set; }

        public PlayerService(PlayerStateModel model, PlayerView view)
        {
            PlayerController = new PlayerMovementController(model, view);
        }
    }
}