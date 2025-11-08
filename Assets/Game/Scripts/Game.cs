public class Game
{
    private readonly PlayerInput _playerInput;
    private readonly Character _character;

    public Game(PlayerInput playerInput, Character character)
    {
        _playerInput = playerInput;
        _character = character;
    }

    public void CustomUpdate()
    {    
        if (_playerInput.RestartPressed)
            _character.Reset();
    }
}