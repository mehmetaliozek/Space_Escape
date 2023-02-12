using UnityEngine;

public class Enemies : MonoBehaviour
{

    [HideInInspector]
    public bool isDestroyable = false;

    private Character character;

    private void Awake()
    {
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
            if (other.tag == Tags.player)
            {
                character.Healt -= other.GetComponent<Character>().AttackDamage;
            }
            else if (other.tag == Tags.playerAttack)
            {
                character.Healt -= other.GetComponent<LaserBeam>().AttackDamage;
            }

            if (character.Healt <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
