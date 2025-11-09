using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameObject _characterPrefab;
    [SerializeField] private float _moveSpeed = 6f;
    [SerializeField] private float _rotationSpeed = 300f;

    [SerializeField, Space(15)] private float _enemySpeedDivider = 1.5f;
    [SerializeField] private Material _enemyMaterial;
    [SerializeField] private PlayerDetector _playerDetectorPrefab;

    [SerializeField, Space(15)] private TargetFollower _cameraTargetFollower;

    [SerializeField, Space(15)] private EnemySpawnPointsContainer _enemySpawnPointsContainer;

    private PlayerInput _playerInput;
    private Game _game;
    private List<IEnemyCharacterBrain> _enemyCharactersBrains = new List<IEnemyCharacterBrain>();

    private void Awake()
    {
        _playerInput = new PlayerInput();

        PlayerCharacterStats playerCharacterStats = new PlayerCharacterStats(_moveSpeed, _rotationSpeed);
        EnemyCharacterStats enemyCharacterStats = new EnemyCharacterStats(_moveSpeed / _enemySpeedDivider, _rotationSpeed, _enemySpawnPointsContainer.SpawnPoints, _enemyMaterial);

        PlayerSpawner playerSpawner = new PlayerSpawner(_characterPrefab, playerCharacterStats);
        IPlayerCharacter playerCharacter = playerSpawner.SpawnPlayer();
        IPlayerCharacterBrain playerCharacterBrain = new PlayerBrain(playerCharacter, _playerInput);

        _cameraTargetFollower.Initialize(playerCharacter.Transform);

        EnemiesSpawner enemiesSpawner = new EnemiesSpawner(_characterPrefab, _playerDetectorPrefab, enemyCharacterStats);
        List<IEnemyCharacter> enemyCharacters = new List<IEnemyCharacter>(enemiesSpawner.SpawnEnemies());

        EnemiesBrainsFactory enemiesBrainsFactory = new EnemiesBrainsFactory();

        foreach (var enemyCharacter in enemyCharacters)
        {
            IEnemyCharacterBrain enemyCharacterBrain = enemiesBrainsFactory.GetBrain(enemyCharacter);

            if (enemyCharacterBrain != null)
                _enemyCharactersBrains.Add(enemyCharacterBrain);
        }

        _game = new Game(_playerInput,
                         playerCharacter,
                         playerCharacterBrain,
                         enemyCharacters,
                         _enemyCharactersBrains);
    }

    private void Update()
    {
        _playerInput.CustomUpdate();
        _game.CustomUpdate();
    }
}