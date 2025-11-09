using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PatrolBetweenPointsBehaviour
{
    private const float DeltaDistance = 0.6f;

    private Queue<Vector3> _waypointsQueue;

    private Vector3 _currentTargetPosition;

    public PatrolBetweenPointsBehaviour(IEnumerable<Transform> waypointTransforms)
    {
        _waypointsQueue = new Queue<Vector3>(waypointTransforms.Select(w => w.position));

        SwitchTarget();
    }

    public Vector3 GetDirection(Vector3 characterPosition)
    {
        if (Vector3.Distance(characterPosition, _currentTargetPosition) <= DeltaDistance)
            SwitchTarget();

        return (_currentTargetPosition - characterPosition).normalized;
    }

    private void SwitchTarget()
    {
        if (_currentTargetPosition != null)
            _waypointsQueue.Enqueue(_currentTargetPosition);

        _currentTargetPosition = _waypointsQueue.Dequeue();
    }
}
