using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class WalkToRandomPointsBehaviour : IBehaviour
{
    private const float SecondsBetweenChangeTarget = 2f;

    private EnemyCharacter _enemyCharacter;

    private bool isActiveBehaviour;
    private DateTime _lastSwitchTime;
    private Vector3 _currentDirection;

    public WalkToRandomPointsBehaviour(EnemyCharacter enemyCharacter)
    {
        _enemyCharacter = enemyCharacter;

        Reset();
    }

    public void Start() => isActiveBehaviour = true;

    public void Stop() => isActiveBehaviour = false;

    public void Reset()
    {
        isActiveBehaviour = true;

        _lastSwitchTime = DateTime.UtcNow;
        ChangeDirection();
    }

    public void CustomUpdate(Vector3 characterPosition)
    {
        if (isActiveBehaviour == false)
            return;

        if ((DateTime.UtcNow - _lastSwitchTime).TotalSeconds >= SecondsBetweenChangeTarget)
        {
            ChangeDirection();
            _lastSwitchTime = DateTime.UtcNow;
        }

        _enemyCharacter.SetMoveDirection(_currentDirection);
        _enemyCharacter.SetRotationDirection(_currentDirection);
    }

    private void ChangeDirection()
    {
        Vector2 randomDirection2D = Random.insideUnitCircle.normalized;

        _currentDirection = new Vector3(randomDirection2D.x, 0f, randomDirection2D.y);
    }
}
