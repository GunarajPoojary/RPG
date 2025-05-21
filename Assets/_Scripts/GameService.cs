using UnityEngine;

namespace RPG
{
    public class GameService : MonoBehaviour
    {
        public static GameService Instance { get; private set; }

        [Header("Models")]
        [SerializeField] private PlayerStateModel _playerStateModel;
        [field: SerializeField] public PlayerFootStepAudioModel PlayerFootStepAudioModel { get; private set; }

        [Header("Views")]
        [SerializeField] private PlayerView _playerView;

        // Services
        public PlayerService PlayerService { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            PlayerService = new PlayerService(_playerStateModel, _playerView);
        }
    }
}