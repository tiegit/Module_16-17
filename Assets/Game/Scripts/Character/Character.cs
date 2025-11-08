using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private CharacterStats _characterStats;

    private Vector3 _initialPosition;
    private Quaternion _initialRotation;

    private DirectionalMover _mover;
    private DirectionalRotator _rotator;

    public void Initialize(CharacterStats characterStats)
    {
        _rigidbody = GetComponent<Rigidbody>();

        _characterStats = characterStats;

        _initialPosition = transform.position;
        _initialRotation = transform.rotation;

        _mover = new DirectionalMover(_rigidbody, _characterStats);
        _rotator = new DirectionalRotator(_rigidbody, _characterStats);
    }

    private void FixedUpdate()
    {
        _mover.CustomFixedUpdate();
        _rotator.CustomFixedUpdate(Time.deltaTime);
    }

    public void SetMoveDirection(Vector3 inputDirection) => _mover.SetInputDirection(inputDirection);

    public void SetRotationDirection(Vector3 inputDirection) => _rotator.SetInputDirection(inputDirection);

    public void Reset()
    {
        transform.position = _initialPosition;
        transform.rotation = _initialRotation;
    }
}