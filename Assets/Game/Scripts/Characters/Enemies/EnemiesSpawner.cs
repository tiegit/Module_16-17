using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemiesSpawner
{
    private GameObject _characterPrefab;
    private EnemyPlayerDetector _enemyPlayerDetectorPrefab;
    private SpawnPoint[] _spawnPoints;
    private EnemyCharacterStats _enemyCharacterStats;

    public EnemiesSpawner(GameObject characterPrefab, EnemyPlayerDetector enemyPlayerDetectorPrefab, EnemyCharacterStats enemyCharacterStats)
    {
        _characterPrefab = characterPrefab;
        _enemyPlayerDetectorPrefab = enemyPlayerDetectorPrefab;
        _enemyCharacterStats = enemyCharacterStats;
        _spawnPoints = _enemyCharacterStats.SpawnPoints.ToArray();
    }

    public IEnumerable<EnemyCharacter> SpawnEnemies()
    {
        List<EnemyCharacter> spawnedEnemies = new List<EnemyCharacter>();

        foreach (SpawnPoint spawnPoint in _spawnPoints)
        {
            GameObject enemyGO = Object.Instantiate(_characterPrefab, spawnPoint.Position, Quaternion.identity);
            EnemyCharacter enemy = enemyGO.AddComponent<EnemyCharacter>();

            EnemyPlayerDetector enemyPlayerDetector = Object.Instantiate(_enemyPlayerDetectorPrefab, spawnPoint.Position, Quaternion.identity, enemy.Transform);

            _enemyCharacterStats.SetWaypointTransforms(spawnPoint.WaypointTransforms);
            _enemyCharacterStats.SetEnemyPlayerDetector(enemyPlayerDetector);

            enemy.Initialize(_enemyCharacterStats);

            spawnedEnemies.Add(enemy);
        }

        return spawnedEnemies;
    }
}