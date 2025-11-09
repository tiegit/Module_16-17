using UnityEngine;

public class NoMoveBehaviour
{
    private EnemyCharacter _enemyCharacter;
    private EnemyPlayerDetector _enemyPlayerDetector;

    public NoMoveBehaviour(EnemyCharacter enemyCharacter, EnemyPlayerDetector enemyPlayerDetector)
    {
        _enemyCharacter = enemyCharacter;
        _enemyPlayerDetector = enemyPlayerDetector;
    }

    public void CustomUpdate()
    {
        //if (_enemyPlayerDetector != null && _enemyPlayerDetector.TargetTransform != null)
        //    _enemyCharacter.SetNewBehaviour();
    }
}
