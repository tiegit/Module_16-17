using UnityEngine;

public class RunAwayBehaviour : IBehaviour
{
    private const float DeltaDistance = 0.6f;

    private EnemyCharacter _enemyCharacter;
    private Transform _targetTransform;

    private bool isActiveBehaviour;

    public RunAwayBehaviour(EnemyCharacter enemyCharacter, PlayerCharacter playerCharacter)
    {
        _targetTransform = playerCharacter.Transform;
        _enemyCharacter = enemyCharacter;
    }

    public void Start() => isActiveBehaviour = true;

    public void Stop() => isActiveBehaviour = false;

    public void Reset() => isActiveBehaviour = true;

    public void CustomUpdate(Vector3 characterPosition)
    {
        if (isActiveBehaviour == false)
            return;

        Vector3 direction;

        if (Vector3.Distance(characterPosition, _targetTransform.position) <= DeltaDistance)
            direction = Vector3.zero;
        else
            direction = (characterPosition - _targetTransform.position).normalized;

        _enemyCharacter.SetMoveDirection(direction);
        _enemyCharacter.SetRotationDirection(direction);
    }
}
