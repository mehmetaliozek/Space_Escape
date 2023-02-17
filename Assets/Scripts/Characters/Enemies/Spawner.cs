using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemies;

    [SerializeField]
    private Sprite[] enemiesSprites;

    [SerializeField]
    private GameObject boost;

    [SerializeField]
    private Sprite[] boostSprites;

    private float countDown;
    private int oldscore;
    private float oldcountDown=2f;
    private int sabit;
    public GameObject Player;

    private float range;

    private float x, y;

    private void Start()
    {
        countDown = 0;
        range = Screen.width / 540.0f;
    }

    private void Update()
    {
        if (GameObject.FindObjectOfType<UIManager>().isPlayable)
        {
            countDown -= Time.deltaTime;
            oldscore=Player.GetComponent<Character>().Score-sabit;
            if(oldscore>=30){
                //bir yerden sonra düşmanlar çok hızlı doğuyor en hızlı 0.8f ile doğsuns
                if(oldcountDown>0.8f){
                   sabit+=30;
                   oldcountDown-=0.3f;
                }
                else{
                    oldcountDown=0.8f;
                }
                
                
            }
            
            if (countDown < 0)
            {
                if (Random.Range(0, 100) < 90)
                {
                    SpawnEnemies(Random.Range(0, enemiesSprites.Length));
                }
                else
                {
                    SpawnBoost(Random.Range(0, boostSprites.Length));
                }
                countDown = oldcountDown;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tags.playerAttack)
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == Tags.enemies)
        {
            other.gameObject.GetComponent<Enemies>().isDestroyable = true;
        }
    }

    private void SpawnEnemies(int randomIndex)
    {
        Character character = enemies.GetComponent<Character>();
        enemies.GetComponent<SpriteRenderer>().sprite = enemiesSprites[randomIndex];
        enemies.GetComponent<Rigidbody2D>().gravityScale = character.MoveSpeed;
        RandomPosition(Random.Range(-range, range));
        Instantiate(enemies, new Vector3(x, y, 0.0f), Quaternion.Euler(180.0f, 0.0f, 0.0f));
    }

    private void SpawnBoost(int randomIndex)
    {
        boost.GetComponent<SpriteRenderer>().sprite = boostSprites[randomIndex];
        RandomPosition(Random.Range(-range, range));
        Instantiate(boost, new Vector3(x, y, 0.0f), Quaternion.identity);
    }

    private void RandomPosition(float randomNumber)
    {
        x = transform.position.x + randomNumber;
        y = transform.position.y;
    }
}