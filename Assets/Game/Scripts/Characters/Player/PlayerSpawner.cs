using UnityEngine;

public class PlayerSpawner
{
    private GameObject _characterPrefab;
    private PlayerCharacterStats _playerCharacterStats;

    public PlayerSpawner(GameObject characterPrefab, PlayerCharacterStats playerCharacterStats)
    {
        _characterPrefab = characterPrefab;
        _playerCharacterStats = playerCharacterStats;
    }

    public PlayerCharacter SpawnPlayer()
    {
        GameObject characterGO = Object.Instantiate(_characterPrefab);
        PlayerCharacter character = characterGO.AddComponent<PlayerCharacter>();

        character.Initialize(_playerCharacterStats);

        return character;
    }
}