public class CharacterStats
{
    private const string StatNameRotaionSpeed = "Здоровье";
    private const string StatNameSpeed = "Скорость движения";

    public CharacterStats(float moveSpeed, float rotationSpeed)
    {
        CurrentMoveSpeed = moveSpeed;
        CurrentRotationSpeed = rotationSpeed;

        //Debug.Log($"<color=purple>Характеристики игрока  \"{StatNameSpeed}\": {CurrentMoveSpeed}, \"{StatNameRotaionSpeed}\": {CurrentRotationSpeed}</color>");
    }

    public float CurrentMoveSpeed { get; private set; }
    public float CurrentRotationSpeed { get; private set; }
}
