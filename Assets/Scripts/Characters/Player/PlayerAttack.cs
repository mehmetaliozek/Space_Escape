using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject parent;

    [SerializeField]
    private GameObject laserBeam;

    private Character character;

    private float countDown;

    private void Start()
    {
        character = parent.GetComponent<Character>();
        countDown = 0;
    }

    private void FixedUpdate()
    {
        if (GameObject.FindObjectOfType<UIManager>().isPlayable)
        {
            countDown -= Time.fixedDeltaTime;
            if (countDown < 0)
            {
                laserBeam.GetComponent<Rigidbody2D>().gravityScale = -5.0f;
                laserBeam.GetComponent<LaserBeam>().AttackDamage = character.AttackDamage;
                Instantiate(laserBeam, transform.position, Quaternion.identity);
                countDown = character.AttackSpeed;
            }
        }

    }
}