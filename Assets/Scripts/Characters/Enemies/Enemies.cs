using UnityEngine;

public class Enemies : MonoBehaviour
{

    [HideInInspector]
    public bool isDestroyable = false;

    private GameObject player;

    private Character character;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
        character = GetComponent<Character>();
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
                character.Healt -= other.GetComponent<LaserBeam>().AttackDamage;
            }

            player.GetComponent<Player>().PlayerScoresUpdate();

            if (character.Healt <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
