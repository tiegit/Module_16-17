using System.Collections.Generic;

public class Game
{
    private readonly PlayerInput _playerInput;
    private readonly IPlayerCharacter _playerCharacter;
    private readonly IPlayerCharacterBrain _playerCharacterBrain;
    private readonly List<IEnemyCharacter> _enemyCharacters;
    private readonly List<IEnemyCharacterBrain> _enemyCharactersBrains;

    public Game(PlayerInput playerInput,
                IPlayerCharacter playerCharacter,
                IPlayerCharacterBrain playerCharacterBrain,
                IEnumerable<IEnemyCharacter> enemyCharacters,
                IEnumerable<IEnemyCharacterBrain> enemyCharactersBrains)
    {
        _playerInput = playerInput;
        _playerCharacter = playerCharacter;
        _playerCharacterBrain = playerCharacterBrain;
        _enemyCharacters = new List<IEnemyCharacter>(enemyCharacters);
        _enemyCharactersBrains = new List<IEnemyCharacterBrain>(enemyCharactersBrains);
    }

    public void CustomUpdate()
    {
        _playerCharacterBrain.CustomUpdate();

        if (_enemyCharactersBrains != null && _enemyCharactersBrains.Count > 0)
        {
            foreach (IEnemyCharacterBrain enemyCharacterBrain in _enemyCharactersBrains)
                enemyCharacterBrain?.CustomUpdate();
        }

        if (_playerInput.RestartPressed)
        {
            _playerCharacter.Reset();

            foreach (IEnemyCharacter enemyCharacter in _enemyCharacters)
                enemyCharacter.Reset();
        }
    }
}