using UnityEngine;

public class EnemyPlayerDetector : MonoBehaviour
{
    public Transform TargetTransform { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerCharacter player))
            TargetTransform = player.Transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerCharacter player))
            TargetTransform = null;
    }
}
