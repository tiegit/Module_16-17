using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Character : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    private Vector3 _initialPosition;
    private Quaternion _initialRotation;

    private DirectionalMover _mover;
    private DirectionalRotator _rotator;

    public Transform Transform => transform;

    public virtual void Initialize(CharacterStats characterStats)
    {
        _rigidbody = GetComponent<Rigidbody>();

        _initialPosition = transform.position;
        _initialRotation = transform.rotation;

        _mover = new DirectionalMover(_rigidbody, characterStats);
        _rotator = new DirectionalRotator(_rigidbody, characterStats);
    }

    private void FixedUpdate()
    {
        _mover?.CustomFixedUpdate();
        _rotator?.CustomFixedUpdate(Time.deltaTime);
    }

    public void SetMoveDirection(Vector3 inputDirection) => _mover.SetInputDirection(inputDirection);

    public void SetRotationDirection(Vector3 inputDirection) => _rotator.SetInputDirection(inputDirection);

    public void Reset()
    {
        _rigidbody.isKinematic = true;

        transform.position = _initialPosition;
        transform.rotation = _initialRotation;

        _rigidbody.isKinematic = false;
    }
}