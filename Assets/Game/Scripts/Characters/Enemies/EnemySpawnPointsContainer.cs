using UnityEngine;

public class EnemySpawnPointsContainer : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoint;

    public SpawnPoint[] SpawnPoints => _spawnPoint;
}