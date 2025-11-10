public class EnemyBrain
{
    private IBehaviour _idleBehaviour;
    private IBehaviour _reactionBehaviour;

    private IBehaviour _currentBehaviour;
    private EnemyCharacter _enemyCharacter;

    public EnemyBrain(EnemyCharacter enemyCharacter, IBehaviour idleBehaviour, IBehaviour reactionBehaviour)
    {
        _enemyCharacter = enemyCharacter;
        _idleBehaviour = idleBehaviour;
        _reactionBehaviour = reactionBehaviour;

        SetBehaviour(_idleBehaviour);
    }

    private void SetBehaviour(IBehaviour newBehaviour)
    {
        _currentBehaviour?.Stop();
        _currentBehaviour = newBehaviour;
        _currentBehaviour.Start();
    }

    public void CustomUpdate()
    {
        _currentBehaviour?.CustomUpdate(_enemyCharacter.Transform.position);
    }

    public void Reset()
    {
        _currentBehaviour.Reset();
    }
}
