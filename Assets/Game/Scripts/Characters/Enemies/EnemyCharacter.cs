using UnityEngine;

public class EnemyCharacter : Character, IEnemyCharacter
{
    public EnemyCharacterStats EnemyCharacterStats { get; private set; }

    public override void Initialize(CharacterStats characterStats)
    {
        base.Initialize(characterStats);

        EnemyCharacterStats = characterStats as EnemyCharacterStats;

        SetEnemyMaterial();
    }

    private void SetEnemyMaterial()
    {
        MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();

        if (meshRenderer != null)
            meshRenderer.material = EnemyCharacterStats.Material;

    }
}
