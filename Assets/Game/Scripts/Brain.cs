using UnityEngine;

public class Brain
{
    private Character _character;
    private PlayerInput _playerInput;

    public Brain(Character character, PlayerInput playerInput)
    {
        _character = character;
        _playerInput = playerInput;
    }

    public void CustomUpdate()
    {
        Vector3 direction = new Vector3(_playerInput.HorizontalInput, 0, _playerInput.VerticalInput);

        _character.SetMoveDirection(direction);
        _character.SetRotationDirection(direction);
    }
}