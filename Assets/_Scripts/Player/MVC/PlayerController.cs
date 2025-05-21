using System.Collections;
using UnityEngine;

namespace RPG
{
    public class PlayerController
    {
        private readonly PlayerView _view;

        public PlayerMovementStateMachine PlayerMovementStateMachine { get; private set; }

        public PlayerController(PlayerView view)
        {
            _view = Object.Instantiate(view);
            _view.SetController(this);
        }

        public void InitPlayerStateMachine(PlayerStateModel model)
        {
            PlayerMovementStateMachine = new PlayerMovementStateMachine(model, _view);
        }
    }
}