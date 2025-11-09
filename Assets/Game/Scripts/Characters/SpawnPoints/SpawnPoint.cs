using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private IdleBehaviour _idleBehaviour = IdleBehaviour.None;
    [SerializeField] private EnemyReaction _enemyReaction = EnemyReaction.None;

    [SerializeField] private Transform[] _waypointTransforms;

    public IdleBehaviour IdleBehaviour => _idleBehaviour;
    public EnemyReaction EnemyReaction => _enemyReaction;

    public Vector3 Position => transform.position;

    public bool HasWaypoints => _waypointTransforms != null && _waypointTransforms.Length > 0;
    public Transform[] WaypointTransforms => _waypointTransforms;
}