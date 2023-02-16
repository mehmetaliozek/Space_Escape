using UnityEngine;
using UnityEngine.UI;

public class BoostBox : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private float time = 5f;
    public string boostTag;
    private Image sprite;

    private void Start()
    {
        sprite = gameObject.GetComponentsInChildren<Image>()[1];
    }

    private void Update()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
            sprite.fillAmount = 1 - (time / 5);
        }
        if (sprite.fillAmount >= 1)
        {
            sprite.fillAmount = 0;
            switch (boostTag)
            {
                case Tags.attackBoost:
                    player.GetComponent<Player>().weaponLeft.SetActive(false);
                    player.GetComponent<Player>().weaponRight.SetActive(false);
                    player.GetComponent<Character>().AttackDamage = 5f;
                    break;
                case Tags.attackSpeedBoost:
                    player.GetComponent<Character>().AttackSpeed = 1f;
                    break;
                case Tags.moveSpeedBoost:
                    player.GetComponent<Character>().MoveSpeed = 0.05f;
                    break;
            }
            gameObject.SetActive(false);
        }
    }

    public void TimeReset()
    {
        time = 5f;
    }
}