using UnityEngine;

public class Enemies : MonoBehaviour
{

    [HideInInspector]
    public bool isDestroyable = false;

    private GameObject player;

    private Character character;

    private UIManager uıManager;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
        character = GetComponent<Character>();
        uıManager = GameObject.FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDestroyable)
        {
            if (other.tag == Tags.playerAttack)
            {
                
                player.GetComponent<Character>().Gold+=1;
                uıManager.GoldUpdate(player.GetComponent<Character>().Gold.ToString());
                character.Healt -= other.GetComponent<LaserBeam>().AttackDamage;
                Destroy(other.gameObject);
            }

            player.GetComponent<Player>().PlayerScoresUpdate();

            if (character.Healt <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
