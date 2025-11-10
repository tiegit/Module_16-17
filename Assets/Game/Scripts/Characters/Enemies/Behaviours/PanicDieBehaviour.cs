using UnityEngine;

public class PanicDieBehaviour : IBehaviour
{
    private EnemyCharacter _enemyCharacter;
    private EnemyPlayerDetector _enemyPlayerDetector;

    private bool isActiveBehaviour;

    public PanicDieBehaviour(EnemyCharacter enemyCharacter)
    {
        _enemyCharacter = enemyCharacter;
        _enemyPlayerDetector = enemyCharacter.EnemyCharacterStats.EnemyPlayerDetector;
    }

    public void Start() => isActiveBehaviour = true;

    public void Stop() => isActiveBehaviour = false;

    public void Reset() => isActiveBehaviour = true;

    public void CustomUpdate(Vector3 characterPosition)
    {
        if (isActiveBehaviour == false)
            return;

        if (_enemyPlayerDetector != null && _enemyPlayerDetector.TargetTransform != null)
        {
            _enemyCharacter.DeactivateEnemy();
            _enemyPlayerDetector.Reset();
        }
    }
}