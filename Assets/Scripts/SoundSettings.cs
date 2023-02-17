using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour, IDataPersistence
{
    [SerializeField] private GameObject sliderMusic;
    [SerializeField] private GameObject sliderSFX;

    private UIManager uıManager;

    private void Awake()
    {
        uıManager = GameObject.FindObjectOfType<UIManager>();
    }

    public void LoadData(GameData data)
    {
        this.sliderMusic.GetComponent<Slider>().value = data.music;
        this.sliderSFX.GetComponent<Slider>().value = data.sfx;
        uıManager.AudioChangeMusic(this.sliderMusic);
        uıManager.AudioChangeSFX(this.sliderSFX);
        gameObject.SetActive(false);
    }

    public void SaveData(ref GameData data)
    {
        data.music = this.sliderMusic.GetComponent<Slider>().value;
        data.sfx = this.sliderSFX.GetComponent<Slider>().value;
    }
}