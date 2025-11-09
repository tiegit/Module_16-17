public class CharacterStats
{
    public CharacterStats(float moveSpeed, float rotationSpeed)
    {
        CurrentMoveSpeed = moveSpeed;
        CurrentRotationSpeed = rotationSpeed;
    }

    public float CurrentMoveSpeed { get; }
    public float CurrentRotationSpeed { get; }
}
