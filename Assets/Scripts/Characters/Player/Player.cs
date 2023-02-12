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
                character.AttackDamage += 0;
                break;
            case Tags.attackSpeedBoost:
                character.AttackSpeed += 0;
                break;
            case Tags.moveSpeedBoost:
                character.MoveSpeed += 0;
                break;
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

    public void PlayerReset()
    {
        character.Healt = characterClone.Healt;
    }
}
