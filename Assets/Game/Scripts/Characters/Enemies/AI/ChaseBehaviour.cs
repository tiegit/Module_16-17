using UnityEngine;

public class ChaseBehaviour
{
    private const float DeltaDistance = 0.6f;

    private Transform _targetTransform;

    public ChaseBehaviour(Transform targetTransform) => _targetTransform = targetTransform;

    public Vector3 GetDirection(Vector3 characterPosition)
    {
        if (Vector3.Distance(characterPosition, _targetTransform.position) <= DeltaDistance)
            return Vector3.zero;

        return (_targetTransform.position - characterPosition).normalized;
    }
}
