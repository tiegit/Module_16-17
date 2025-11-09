public class PanicDieBehaviour
{
    private EnemyCharacter _enemyCharacter;
    private EnemyPlayerDetector _enemyPlayerDetector;

    public PanicDieBehaviour(EnemyCharacter enemyCharacter, EnemyPlayerDetector enemyPlayerDetector)
    {
        _enemyCharacter = enemyCharacter;
        _enemyPlayerDetector = enemyPlayerDetector;
    }

    public void CustomUpdate()
    {
        if (_enemyPlayerDetector != null && _enemyPlayerDetector.TargetTransform != null)
            _enemyCharacter.Kill();
    }
}