using UnityEngine;

public class ChaseBehaviour : IBehaviour
{
    private const float DeltaDistance = 0.6f;

    private EnemyCharacter _enemyCharacter;
    private PlayerCharacter _playerCharacter;

    private bool isActiveBehaviour;

    public ChaseBehaviour(EnemyCharacter enemyCharacter, PlayerCharacter playerCharacter)
    {
        _enemyCharacter = enemyCharacter;
        _playerCharacter = playerCharacter;
    }

    public void Start() => isActiveBehaviour = true;

    public void Stop() => isActiveBehaviour = false;

    public void Reset() => isActiveBehaviour = true;

    public void CustomUpdate(Vector3 characterPosition)
    {
        if (isActiveBehaviour == false)
            return;

        Vector3 direction;

        if (Vector3.Distance(characterPosition, _playerCharacter.Transform.position) <= DeltaDistance)
            direction = Vector3.zero;
        else
            direction = (_playerCharacter.Transform.position - characterPosition).normalized;

        _enemyCharacter.SetMoveDirection(direction);
        _enemyCharacter.SetRotationDirection(direction);
    }
}