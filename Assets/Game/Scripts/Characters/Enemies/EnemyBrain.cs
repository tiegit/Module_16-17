using UnityEngine;

public class EnemyBrain
{
    private IBehaviour _idleBehaviour;
    private IBehaviour _reactionBehaviour;

    private IBehaviour _currentBehaviour;
    private EnemyCharacter _enemyCharacter;
    private EnemyPlayerDetector _enemyPlayerDetector;

    public EnemyBrain(EnemyCharacter enemyCharacter, IBehaviour idleBehaviour, IBehaviour reactionBehaviour)
    {
        _enemyCharacter = enemyCharacter;
        _enemyPlayerDetector = enemyCharacter.EnemyCharacterStats.EnemyPlayerDetector;

        _idleBehaviour = idleBehaviour;
        _reactionBehaviour = reactionBehaviour;

        SetBehaviour(_idleBehaviour);
    }

    private void SetBehaviour(IBehaviour newBehaviour)
    {
        if (_currentBehaviour == newBehaviour)
            return;

        _currentBehaviour?.Stop();
        _currentBehaviour = newBehaviour;
        _currentBehaviour.Start();

        Debug.Log($"{_currentBehaviour}");
    }

    public void CustomUpdate()
    {
        UpdateBehaviourState();

        _currentBehaviour?.CustomUpdate(_enemyCharacter.Transform.position);
    }

    private void UpdateBehaviourState()
    {
        if (_enemyPlayerDetector.TargetTransform == null && _currentBehaviour == _idleBehaviour)
            return;
        else if (_enemyPlayerDetector.TargetTransform == null && _currentBehaviour != _idleBehaviour)
            SetBehaviour(_idleBehaviour);
        else if (_enemyPlayerDetector.TargetTransform != null && _currentBehaviour == _idleBehaviour)
            SetBehaviour(_reactionBehaviour);

        Debug.Log($"{_currentBehaviour}");
    }

    public void Reset() => _currentBehaviour.Reset();
}