using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PatrolBetweenPointsBehaviour : IBehaviour
{
    private const float DeltaDistance = 0.6f;

    private EnemyCharacter _enemyCharacter;
    private Queue<Vector3> _waypointsQueue;

    private Vector3 _currentTargetPosition;
    private bool isActiveBehaviour;

    public PatrolBetweenPointsBehaviour(EnemyCharacter enemyCharacter)
    {
        _enemyCharacter = enemyCharacter;
        _waypointsQueue = new Queue<Vector3>(enemyCharacter.EnemyCharacterStats.WaypointTransforms.Select(w => w.position));

        SwitchTarget();
    }

    public void Start() => isActiveBehaviour = true;

    public void Stop() => isActiveBehaviour = false;

    public void Reset()
    {
        isActiveBehaviour = true;

        SwitchTarget();
    }

    public void CustomUpdate(Vector3 characterPosition)
    {
        if (isActiveBehaviour == false)
            return;

        if (Vector3.Distance(characterPosition, _currentTargetPosition) <= DeltaDistance)
            SwitchTarget();

        Vector3 direction = (_currentTargetPosition - characterPosition).normalized;

        _enemyCharacter.SetMoveDirection(direction);
        _enemyCharacter.SetRotationDirection(direction);
    }

    private void SwitchTarget()
    {
        if (_currentTargetPosition != Vector3.zero)
            _waypointsQueue.Enqueue(_currentTargetPosition);

        _currentTargetPosition = _waypointsQueue.Dequeue();
    }
}
