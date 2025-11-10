using UnityEngine;

public class EnemyCharacter : Character
{
    public EnemyCharacterStats EnemyCharacterStats { get; private set; }

    public override void Initialize(CharacterStats characterStats)
    {
        base.Initialize(characterStats);

        EnemyCharacterStats = characterStats as EnemyCharacterStats;

        SetEnemyMaterial();
    }

    public void ToggleActivity(bool isActive)
    {
        if (isActive == false)
        {
            //TODO добавить эффект уничтожения
        }

        gameObject.SetActive(isActive);
    }

    private void SetEnemyMaterial()
    {
        MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();

        if (meshRenderer != null)
            meshRenderer.material = EnemyCharacterStats.Material;
    }
}
