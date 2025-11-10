using UnityEngine;

public class EnemiesBrainsFactory
{
    public EnemyBrain GetBrain(EnemyCharacter enemyCharacter, PlayerCharacter playerCharacter)
    {
        IdleBehaviour selectedIdleBehaviour = enemyCharacter.EnemyCharacterStats.SpawnPoint.IdleBehaviour;
        EnemyReaction selectedReactionBehaviour = enemyCharacter.EnemyCharacterStats.SpawnPoint.EnemyReaction;

        IBehaviour idleBehavior = null;
        IBehaviour reactionBehaviour = null;

        switch (selectedIdleBehaviour)
        {
            case IdleBehaviour.None:
            case IdleBehaviour.NoMove:
                idleBehavior = new NoMoveBehaviour(enemyCharacter);
                break;

            case IdleBehaviour.PatrolBetweenPoints:
                idleBehavior = new PatrolBetweenPointsBehaviour(enemyCharacter);
                break;

            case IdleBehaviour.WalkToRandomPoints:
                idleBehavior = new WalkToRandomPointsBehaviour(enemyCharacter);
                break;

            default:
                Debug.LogWarning($"Unsupported IdleBehaviour: {selectedIdleBehaviour}.");
                break;
        }

        switch (selectedReactionBehaviour)
        {
            case EnemyReaction.None:
                reactionBehaviour = new NoMoveBehaviour(enemyCharacter);
                break;

            case EnemyReaction.RunAway:
                reactionBehaviour = new RunAwayBehaviour(enemyCharacter, playerCharacter);
                break;

            case EnemyReaction.Chase:
                reactionBehaviour = new ChaseBehaviour(enemyCharacter, playerCharacter);
                break;

            case EnemyReaction.PanicAndDie:
                reactionBehaviour = new PanicDieBehaviour(enemyCharacter);
                break;

            default:
                Debug.LogWarning($"Unsupported ReactionBehaviour: {selectedReactionBehaviour}.");
                break;
        }

        EnemyBrain enemyBrain = new EnemyBrain(enemyCharacter, idleBehavior, reactionBehaviour);

        return enemyBrain;
    }
}