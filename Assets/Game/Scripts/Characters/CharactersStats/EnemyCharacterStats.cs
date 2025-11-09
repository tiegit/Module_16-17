using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyCharacterStats : CharacterStats
{
    public EnemyCharacterStats(float moveSpeed, float rotationSpeed, IEnumerable<SpawnPoint> spawnPoints, Material material)
        : base(moveSpeed, rotationSpeed)
    {
        SpawnPoints = spawnPoints.ToArray();
        Material = material;
    }

    public SpawnPoint[] SpawnPoints { get; }
    public Material Material { get; }
    public Transform[] WaypointTransforms { get; private set; }
    public EnemyPlayerDetector EnemyPlayerDetector { get; private set; }

    public void SetWaypointTransforms(IEnumerable<Transform> waypointTransforms) => WaypointTransforms = waypointTransforms.ToArray();

    public void SetEnemyPlayerDetector(EnemyPlayerDetector enemyPlayerDetector) => EnemyPlayerDetector = enemyPlayerDetector;
}
