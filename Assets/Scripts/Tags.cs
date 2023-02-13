public class Tags
{
    public const string player = "Player";
    public const string playerAttack = "PlayerAttack";

    public const string enemies = "Enemies";

    public const string attackBoost = "AttackBoost";
    public const string attackSpeedBoost = "AttackSpeedBoost";
    public const string moveSpeedBoost = "MoveSpeedBoost";
    public const string gold = "Gold";
    public const string healt = "Healt";

    static public string[] getTags()
    {
        return new string[7] { playerAttack, enemies, attackBoost, attackSpeedBoost, moveSpeedBoost, gold, healt };
    }
}