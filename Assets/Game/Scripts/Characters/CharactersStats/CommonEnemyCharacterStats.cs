using UnityEngine;

public class CommonEnemyCharacterStats : CharacterStats
{
    public CommonEnemyCharacterStats(float moveSpeed, float rotationSpeed, Material material)
        : base(moveSpeed, rotationSpeed)
    {
        Material = material;
    }

    public Material Material { get; }
}