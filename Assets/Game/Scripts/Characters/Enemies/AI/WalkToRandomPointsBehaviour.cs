using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WalkToRandomPointsBehaviour
{
    private const float DeltaDistance = 0.6f;

    private List<Vector3> _waypoints;

    private Vector3 _currentTargetPosition;

    public WalkToRandomPointsBehaviour(IEnumerable<Transform> waypointTransforms)
    {
        _waypoints = new List<Vector3>(waypointTransforms.Select(w => w.position));

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
        int randomIndex = Random.Range(0, _waypoints.Count);

        _currentTargetPosition = _waypoints[randomIndex];
    }
}
