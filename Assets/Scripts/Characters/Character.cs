using UnityEngine;

public class Character : MonoBehaviour
{
    //Karakterin canı
    [SerializeField]
    private float healt;

    //Karakterin saldırı gücü
    [SerializeField]
    private float attackDamage;

    //Karakterin saldırı hızı
    [SerializeField]
    private float attackSpeed;

    //Karakterin hareket hızı
    [SerializeField]
    private float moveSpeed;

    //Karaktrin puanı
    [SerializeField]
    private int score;

    //Karaktrin en yüksek puanı
    [SerializeField]
    private int highScore;

    [SerializeField]
    private int gold;

    public Character(float healt, float attackDamage, float attackSpeed, float moveSpeed, int score, int highScore, int gold)
    {
        this.healt = healt;
        this.attackDamage = attackDamage;
        this.attackSpeed = attackSpeed;
        this.moveSpeed = moveSpeed;
        this.score = score;
        this.highScore = highScore;
        this.gold = gold;
    }


    // Getters ve Setters
    public float Healt
    {
        get { return healt; }
        set { healt = value; }
    }
    public float AttackDamage
    {
        get { return attackDamage; }
        set { attackDamage = value; }
    }
    public float AttackSpeed
    {
        get { return attackSpeed; }
        set { attackSpeed = value; }
    }
    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public int HighScore
    {
        get { return highScore; }
        set { highScore = value; }
    }

    public int Gold
    {
        get { return gold; }
        set { gold = value; }
    }

    public Character Clone()
    {
        return new Character(healt, attackDamage, attackSpeed, moveSpeed, score, highScore, gold);
    }
}
