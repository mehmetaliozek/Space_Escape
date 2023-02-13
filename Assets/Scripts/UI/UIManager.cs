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
    [SerializeField] private GameObject spaceShips;
    [SerializeField] private GameObject galaxies;

    [SerializeField] private GameObject Ses;

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

    public void AudioChange(GameObject Slider)
    {
        Ses.GetComponent<AudioSource>().volume = Slider.GetComponent<Slider>().value;
    }

    public void TabChange(bool isSpaceShip)
    {
        if (isSpaceShip)
        {
            spaceShips.SetActive(false);
            galaxies.SetActive(true);
        }
        else
        {
            spaceShips.SetActive(true);
            galaxies.SetActive(false);
        }
    }
}