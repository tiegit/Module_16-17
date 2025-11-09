using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private IEnemyCharacter _enemyOwner;

    public void Initialize(IEnemyCharacter enemy) => _enemyOwner = enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IPlayerCharacter player))
        {
            Debug.Log($"Я {_enemyOwner.GetType()} обнаружил {player.GetType()}");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IPlayerCharacter player))
        {
            Debug.Log($"Я {_enemyOwner.GetType()} потерял из виду {player.GetType()}");
        }
    }
}
