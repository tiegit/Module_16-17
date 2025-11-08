using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Character _characterPrefab;
    [SerializeField] private float _moveSpeed = 6f;
    [SerializeField] private float _rotationSpeed = 300f;

    [SerializeField, Space(15)] private TargetFollower _cameraTargetFollower;

    private PlayerInput _playerInput;
    private Character _playerCharacter;
    private Brain _playerBrain;
    private Game _game;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        CharacterStats characterStats = new CharacterStats(_moveSpeed, _rotationSpeed);

        PlayerSpawner playerInstaller = new PlayerSpawner(_characterPrefab, _playerInput, characterStats);
        playerInstaller.SpawnPlayer(out _playerCharacter, out _playerBrain);

        _cameraTargetFollower.Initialize(_playerCharacter.transform);

        _game = new Game(_playerInput, _playerCharacter);
    }

    private void Update()
    {
        _playerInput.CustomUpdate();
        _playerBrain.CustomUpdate();
        _game.CustomUpdate();
    }
}
