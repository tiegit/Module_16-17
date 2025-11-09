using UnityEngine;

public interface ICharacter
{
    Transform Transform { get; }

    void Initialize(CharacterStats characterStats);
    void SetMoveDirection(Vector3 inputDirection);
    void SetRotationDirection(Vector3 inputDirection);
    void Reset();
}