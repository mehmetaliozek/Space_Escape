using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool isPlayable = false;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject game;
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject scores;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private Text score;
    [SerializeField] private Text highScore;
    [SerializeField] private GameObject gold;
    [SerializeField] private GameObject healt;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] spaceShips;
    [SerializeField] private GameObject[] galaxies;

    [SerializeField] private GameObject ses;
    [SerializeField] private GameObject sesFx;

    [SerializeField] private GameObject sesFx2;
    [SerializeField] private GameObject attackBoostBox;
    [SerializeField] private GameObject attackSpeedBoostBox;
    [SerializeField] private GameObject moveSpeedBoostBox;

    private GameObject pauseAndResumeButton;
    private Animator playerAnimator;

    private void Start()
    {
        pauseAndResumeButton = game.transform.GetChild(0).gameObject;
        playerAnimator = player.GetComponent<Animator>();
        HealtUpdate(player.GetComponent<Character>().Healt.ToString());
    }

    public void StartGame()
    {
        isPlayable = true;
        mainMenu.SetActive(false);
        game.SetActive(true);
        scores.SetActive(true);
        healt.SetActive(true);
        playerAnimator.SetTrigger("moveDown");
    }

    public void PauseAndResumeGame()
    {
        if (playerAnimator.enabled == false)
        {
            isPlayable = Time.timeScale == 0 ? true : false;
            game.SetActive(isPlayable);
            pause.SetActive(!isPlayable);
            Time.timeScale = isPlayable ? 1 : 0;
        }
    }

    public void ExitAndRestartGame(bool isRestart)
    {
        Time.timeScale = 1;
        playerAnimator.enabled = true;
        if (isRestart)
        {
            isPlayable = true;
            playerAnimator.SetTrigger("moveDown");
        }
        else
        {
            isPlayable = false;
            mainMenu.SetActive(true);
            game.SetActive(false);
            scores.SetActive(false);
            healt.SetActive(false);
            pause.SetActive(false);
        }
        gameOver.SetActive(false);
        foreach (var tag in Tags.getTags())
        {
            foreach (var item in GameObject.FindGameObjectsWithTag(tag))
            {
                Destroy(item);
            }
        }

        player.GetComponent<Player>().PlayerReset();
        score.text = "0";
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);
        isPlayable = false;
    }

    public void GoldUpdate(string text)
    {
        gold.GetComponentsInChildren<Text>()[0].text = text;
    }

    public void HealtUpdate(string text)
    {
        healt.GetComponentsInChildren<Text>()[0].text = text;
    }

    public void ScoresUpdate(string text)
    {
        score.text = text;
        if (int.Parse(text) >= int.Parse(highScore.text))
        {
            highScore.text = text;
        }
    }

    public void OpenAndCloseSettings(bool value)
    {
        settings.SetActive(value);
    }

    public void OpenAndCloseShop(bool value)
    {
        shop.SetActive(value);
        mainMenu.SetActive(!value);
    }

    public void AudioChangeMusic(GameObject slider)
    {
        ses.GetComponent<AudioSource>().volume = slider.GetComponent<Slider>().value;
    }

    public void AudioChangeSFX(GameObject slider)
    {
        sesFx.GetComponent<AudioSource>().volume = slider.GetComponent<Slider>().value;
        //Mermi Sesi Çarpışma sesinin üstüne binmemesi için daha az değer alıyor
        sesFx2.GetComponent<AudioSource>().volume = slider.GetComponent<Slider>().value / 4;
    }

    public void TabChange(bool isSpaceShip)
    {
        if (isSpaceShip)
        {
            spaceShips[0].SetActive(false);
            spaceShips[1].SetActive(true);
            galaxies[0].SetActive(true);
            galaxies[1].SetActive(false);
        }
        else
        {
            spaceShips[0].SetActive(true);
            spaceShips[1].SetActive(false);
            galaxies[0].SetActive(false);
            galaxies[1].SetActive(true);
        }
    }

    public void CreateBoost(string boostTag)
    {
        switch (boostTag)
        {
            case Tags.attackBoost:
                attackBoostBox.GetComponent<BoostBox>().TimeReset();
                attackBoostBox.SetActive(true);
                break;
            case Tags.attackSpeedBoost:
                attackSpeedBoostBox.GetComponent<BoostBox>().TimeReset();
                attackSpeedBoostBox.SetActive(true);
                break;
            case Tags.moveSpeedBoost:
                moveSpeedBoostBox.GetComponent<BoostBox>().TimeReset();
                moveSpeedBoostBox.SetActive(true);
                break;
        }
    }
}