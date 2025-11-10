using UnityEngine;

public class CommonEnemyCharacterStats : CharacterStats
{
    public CommonEnemyCharacterStats(float moveSpeed, float rotationSpeed, Material material, GameObject explosionPrefab)
        : base(moveSpeed, rotationSpeed)
    {
        Material = material;
        ExplosionPrefab = explosionPrefab;
    }

    public Material Material { get; }
    public GameObject ExplosionPrefab { get; }
}