using UnityEngine;

public class EnemyCharacter : Character
{
    private Vector3 _offset = new Vector3(0, 2, 0);

    public EnemyCharacterStats EnemyCharacterStats { get; private set; }

    public override void Initialize(CharacterStats characterStats)
    {
        base.Initialize(characterStats);

        EnemyCharacterStats = characterStats as EnemyCharacterStats;

        SetEnemyMaterial();
    }

    public void DeactivateEnemy()
    {
        Instantiate(EnemyCharacterStats.ExplosionPrefab, Transform.position + _offset, Quaternion.identity);

        gameObject.SetActive(false);
    }

    private void SetEnemyMaterial()
    {
        MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();

        if (meshRenderer != null)
            meshRenderer.material = EnemyCharacterStats.Material;
    }
}
