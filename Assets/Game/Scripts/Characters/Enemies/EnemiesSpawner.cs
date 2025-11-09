using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemiesSpawner
{
    private GameObject _characterPrefab;
    private PlayerDetector _playerDetectorPrefab;
    private SpawnPoint[] _spawnPoints;
    private EnemyCharacterStats _enemyCharacterStats;

    public EnemiesSpawner(GameObject characterPrefab, PlayerDetector playerDetectorPrefab, EnemyCharacterStats enemyCharacterStats)
    {
        _characterPrefab = characterPrefab;
        _playerDetectorPrefab = playerDetectorPrefab;
        _enemyCharacterStats = enemyCharacterStats;
        _spawnPoints = _enemyCharacterStats.SpawnPoints.ToArray();
    }

    public IEnumerable<IEnemyCharacter> SpawnEnemies()
    {
        List<IEnemyCharacter> spawnedEnemies = new List<IEnemyCharacter>();

        foreach (SpawnPoint spawnPoint in _spawnPoints)
        {
            GameObject enemyGO = Object.Instantiate(_characterPrefab, spawnPoint.Position, Quaternion.identity);
            IEnemyCharacter enemy = enemyGO.AddComponent<EnemyCharacter>();

            PlayerDetector playerDetector = Object.Instantiate(_playerDetectorPrefab, spawnPoint.Position, Quaternion.identity, enemy.Transform);
            playerDetector.Initialize(enemy);

            _enemyCharacterStats.SetWaypointTransforms(spawnPoint.WaypointTransforms);

            enemy.Initialize(_enemyCharacterStats);

            spawnedEnemies.Add(enemy);
        }

        return spawnedEnemies;
    }
}