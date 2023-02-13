using UnityEngine;

public class Boost : MonoBehaviour
{
    private void Start()
    {
        gameObject.tag = setTag(gameObject.GetComponent<SpriteRenderer>().sprite.name.Split("_")[1]);
    }
    private string setTag(string spriteName)
    {
        string tag = "";
        switch (spriteName)
        {
            case "12":
                tag = Tags.attackBoost;
                break;
            case "13":
                tag = Tags.attackSpeedBoost;
                break;
            case "14":
                tag = Tags.moveSpeedBoost;
                break;
            case "15":
                tag = Tags.gold;
                break;
            case "17":
                tag = Tags.healt;
                break;
        }
        return tag;
    }
}