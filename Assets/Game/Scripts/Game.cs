using System.Collections.Generic;

public class Game
{
    private PlayerInput _playerInput;
    private PlayerCharacter _playerCharacter;
    private PlayerController _playerController;
    private List<EnemyCharacter> _enemyCharacters;
    private List<EnemyBrain> _enemyCharactersBrains;

    public Game(PlayerInput playerInput,
                PlayerCharacter playerCharacter,
                PlayerController playerController,
                IEnumerable<EnemyCharacter> enemyCharacters,
                IEnumerable<EnemyBrain> enemyCharactersBrains)
    {
        _playerInput = playerInput;
        _playerCharacter = playerCharacter;
        _playerController = playerController;
        _enemyCharacters = new List<EnemyCharacter>(enemyCharacters);
        _enemyCharactersBrains = new List<EnemyBrain>(enemyCharactersBrains);
    }

    public void CustomUpdate()
    {
        _playerController.CustomUpdate();

        if (_enemyCharactersBrains != null && _enemyCharactersBrains.Count > 0)
        {
            foreach (EnemyBrain enemyCharacterBrain in _enemyCharactersBrains)
                enemyCharacterBrain?.CustomUpdate();
        }

        if (_playerInput.RestartPressed)
        {
            _playerCharacter.Reset();

            foreach (EnemyBrain enemyCharacterBrain in _enemyCharactersBrains)
                enemyCharacterBrain.Reset();

            foreach (EnemyCharacter enemyCharacter in _enemyCharacters)
                enemyCharacter.Reset();
        }
    }
}