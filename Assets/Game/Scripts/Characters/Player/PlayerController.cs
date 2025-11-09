using UnityEngine;

public class PlayerController
{
    private PlayerInput _playerInput;

    public PlayerController(PlayerCharacter character, PlayerInput playerInput)
    {
        PlayerCharacter = character;
        _playerInput = playerInput;
    }

    public PlayerCharacter PlayerCharacter { get; private set; }

    public void CustomUpdate()
    {
        Vector3 direction = new Vector3(_playerInput.HorizontalInput, 0, _playerInput.VerticalInput).normalized;

        PlayerCharacter.SetMoveDirection(direction);
        PlayerCharacter.SetRotationDirection(direction);
    }
}