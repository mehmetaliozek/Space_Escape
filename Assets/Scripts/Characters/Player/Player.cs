using UnityEngine;

public class Player : MonoBehaviour, IDataPersistence
{
    [SerializeField]
    private Camera cam;
    private Touch touch;
    private Vector3 touchPosition;
    private Vector3 position;
    private Character character;
    private Character characterClone;
    private UIManager uıManager;
    //Çarpışma Sesi İçin
    public GameObject AudioSFX;
    public AudioClip Audio;

    public GameObject weaponLeft;
    public GameObject weaponRight;

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
                AudioSFX.GetComponent<AudioSource>().PlayOneShot(Audio);
                character.Healt -= other.GetComponent<Character>().AttackDamage;
                uıManager.HealtUpdate(character.Healt.ToString());
                if (character.Healt <= 0)
                {
                    uıManager.GameOver();
                }
                break;
            case Tags.attackBoost:
                weaponLeft.SetActive(true);
                weaponRight.SetActive(true);
                character.AttackDamage = 10;
                uıManager.CreateBoost(Tags.attackBoost);
                break;
            case Tags.attackSpeedBoost:
                character.AttackSpeed = 0.5f;
                uıManager.CreateBoost(Tags.attackSpeedBoost);
                break;
            case Tags.moveSpeedBoost:
                character.MoveSpeed = 1;
                uıManager.CreateBoost(Tags.moveSpeedBoost);
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

    public void LoadData(GameData data)
    {
        if (data.player != null)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = data.player;
        }
        this.character.HighScore = data.highScore;
        this.character.Gold = data.gold;
        uıManager.GoldUpdate(this.character.Gold.ToString());
        uıManager.LoadHighScore(this.character.HighScore.ToString());
    }

    public void SaveData(ref GameData data)
    {
        data.highScore = this.characterClone.HighScore;
        data.gold = this.characterClone.Gold;
        data.player = this.GetComponent<SpriteRenderer>().sprite;
    }
}
