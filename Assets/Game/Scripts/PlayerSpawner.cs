using UnityEngine;

public class PlayerSpawner
{
    private Character _characterPrefab;
    private PlayerInput _playerInput;
    private CharacterStats _characterStats;

    public PlayerSpawner(Character characterPrefab, PlayerInput playerInput, CharacterStats characterStats)
    {
        _characterPrefab = characterPrefab;
        _playerInput = playerInput;
        _characterStats = characterStats;
    }

    public void SpawnPlayer(out Character character, out Brain brain)
    {
        character = Object.Instantiate(_characterPrefab);
        character.Initialize(_characterStats);

        brain = new Brain(character, _playerInput);
    }
}
