using UnityEngine;

public enum IdleBehaviour
{
    None,
    StayInPlaceWithoutAction,
    PatrolBetweenScenePoints,
    WalkInRandomDirection
}

public enum EnemyReaction
{
    None,
    RunAwayInOppositeDirection,
    AggroAndChase,
    PanicAndDie
}

public class SpawnPointConfig : MonoBehaviour
{
    [SerializeField] private IdleBehaviour _idleBehaviour = IdleBehaviour.None;
    [SerializeField] private EnemyReaction _enemyReaction = EnemyReaction.None;

    [SerializeField] private Transform[] _waypointTransforms;

    public IdleBehaviour IdleBehaviour => _idleBehaviour;
    public EnemyReaction EnemyReaction => _enemyReaction;
    public bool HasWaypoints => _waypointTransforms != null && _waypointTransforms.Length > 0;
    public Transform[] WaypointTransforms => _waypointTransforms;
}