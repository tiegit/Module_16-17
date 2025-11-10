using UnityEngine;

public class NoMoveBehaviour : IBehaviour
{
    private EnemyCharacter _enemyCharacter;

    public NoMoveBehaviour(EnemyCharacter enemyCharacter) => _enemyCharacter = enemyCharacter;

    public void Start()
    { 
        _enemyCharacter.SetMoveDirection(Vector3.zero);
        _enemyCharacter.SetRotationDirection(Vector3.zero);
    }

    public void Stop() { }

    public void Reset() { }

    public void CustomUpdate(Vector3 characterPosition) { }
}
