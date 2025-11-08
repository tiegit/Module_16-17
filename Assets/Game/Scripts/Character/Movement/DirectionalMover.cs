using UnityEngine;

public class DirectionalMover
{
    private Rigidbody _rigidbody;
    CharacterStats _characterStats;

    private Vector3 _currentDirection;

    public DirectionalMover( Rigidbody rigidbody, CharacterStats characterStats)
    {
        _rigidbody = rigidbody;
        _characterStats = characterStats;
    }

    public void CustomFixedUpdate() => _rigidbody.velocity = _currentDirection * _characterStats.CurrentMoveSpeed;

    public void SetInputDirection(Vector3 direction) => _currentDirection = direction;
}
