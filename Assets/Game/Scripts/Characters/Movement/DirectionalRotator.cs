using UnityEngine;

public class DirectionalRotator
{
    private const float SensitivityLimit = 0.05f;

    private Rigidbody _rigidbody;
    CharacterStats _characterStats;

    private Vector3 _currentDirection;

    public DirectionalRotator(Rigidbody rigidbody, CharacterStats characterStats)
    {
        _rigidbody = rigidbody;
        _characterStats = characterStats;
    }

    public void CustomFixedUpdate(float deltaTime)
    {
        if (_currentDirection.magnitude < SensitivityLimit)
            return;

        Vector3 targetDirection = _currentDirection;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

        float maxDegreesDelta = _characterStats.CurrentRotationSpeed * deltaTime;

        Quaternion newRotation = Quaternion.RotateTowards(
            _rigidbody.transform.rotation,
            targetRotation,
            maxDegreesDelta
        );

        _rigidbody.MoveRotation(newRotation);
    }

    public void SetInputDirection(Vector3 direction) => _currentDirection = direction;
}
