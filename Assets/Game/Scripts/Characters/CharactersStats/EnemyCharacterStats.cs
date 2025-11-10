using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyCharacterStats : CommonEnemyCharacterStats
{
    public EnemyCharacterStats(float moveSpeed,
                               float rotationSpeed,
                               Material material,
                               GameObject explosionPrefab,
                               SpawnPoint spawnPoint,
                               IEnumerable<Transform> waypointTransforms,
                               EnemyPlayerDetector enemyPlayerDetector)
        : base(moveSpeed, rotationSpeed, material, explosionPrefab)
    {
        SpawnPoint = spawnPoint;
        WaypointTransforms = waypointTransforms.ToArray();
        EnemyPlayerDetector = enemyPlayerDetector;
    }

    public SpawnPoint SpawnPoint { get; }
    public Transform[] WaypointTransforms { get; }
    public EnemyPlayerDetector EnemyPlayerDetector { get; }
}
