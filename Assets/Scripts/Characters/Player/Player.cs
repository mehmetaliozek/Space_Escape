using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    private Touch touch;
    private Vector3 touchPosition;
    private Vector3 position;
    private Character character;
    private Character characterClone;
    private UIManager uıManager;

    private void Awake()
    {
        if (!cam) cam = Camera.main;

        character = GetComponent<Character>();

        characterClone = character.Clone();

        uıManager = GameObject.FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        if (uıManager.isPlayable)
        {
            MovePlayer(character.MoveSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case Tags.enemies:
                character.Healt -= other.GetComponent<Character>().AttackDamage;
                uıManager.HealtUpdate(character.Healt.ToString());
                if (character.Healt <= 0)
                {
                    uıManager.GameOver();
                }
                break;
            case Tags.attackBoost:
                character.AttackDamage = 6;
                break;
            case Tags.attackSpeedBoost:
                character.AttackSpeed = 0.5f;
                break;
            case Tags.moveSpeedBoost:
                character.MoveSpeed = 1;
                break;
            case Tags.gold:
                character.Gold += 1;
                uıManager.GoldUpdate(character.Gold.ToString());
                break;
            case Tags.healt:
                character.Healt += 1;
                uıManager.HealtUpdate(character.Healt.ToString());
                break;
        }
        if (other.tag != Tags.playerAttack)
        {
            Destroy(other.gameObject);
        }
    }

    private void MovePlayer(float moveSpeed)
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            touchPosition = cam.ScreenToWorldPoint(touch.position);
            position = new Vector3(touchPosition.x, transform.position.y, 0.0f);
            transform.position = Vector3.Lerp(transform.position, position, moveSpeed * Time.maximumDeltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    private void AnimatorStop()
    {
        GetComponent<Animator>().enabled = false;
    }

    public void PlayerScoresUpdate()
    {
        character.Score += 1;

        if (character.Score >= character.HighScore)
        {
            character.HighScore = character.Score;
        }

        uıManager.ScoresUpdate(character.Score.ToString());
    }

    public void PlayerReset()
    {
        character.Healt = characterClone.Healt;
        character.AttackDamage = characterClone.AttackDamage;
        character.AttackSpeed = characterClone.AttackSpeed;
        character.MoveSpeed = characterClone.MoveSpeed;
        character.Score = characterClone.Score;
        characterClone.HighScore = character.HighScore;
        characterClone.Gold = character.Gold;

        uıManager.HealtUpdate(character.Healt.ToString());
    }
}
