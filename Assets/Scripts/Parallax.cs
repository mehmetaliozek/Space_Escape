using UnityEngine;

public class Parallax : MonoBehaviour, IDataPersistence
{
    public void LoadData(GameData data)
    {
        if (data.parallax != null)
        {
            this.gameObject.GetComponentsInChildren<SpriteRenderer>()[1].sprite = data.parallax;
            this.gameObject.GetComponentsInChildren<SpriteRenderer>()[2].sprite = data.parallax;
        }
    }

    public void SaveData(ref GameData data)
    {
        data.parallax = this.GetComponentsInChildren<SpriteRenderer>()[1].sprite;
    }
}