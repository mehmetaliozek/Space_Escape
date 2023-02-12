using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool isPlayable = false;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject game;
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject scores;
    [SerializeField] private Text score;
    [SerializeField] private Text highScore;
    [SerializeField] private GameObject healt;
    [SerializeField] private GameObject player;

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

    public void ExitGame()
    {
        Time.timeScale = 1;
        isPlayable = false;
        playerAnimator.enabled = true;
        mainMenu.SetActive(true);
        game.SetActive(false);
        scores.SetActive(false);
        healt.SetActive(false);
        pause.SetActive(false);
        foreach (var item in GameObject.FindGameObjectsWithTag(Tags.enemies))
        {
            Destroy(item);
        }
        player.GetComponent<Player>().PlayerReset();
        score.text = "0";
    }

    public void GameOver()
    {
        if (player.GetComponent<Character>().Healt <= 0)
        {
            ExitGame();
        }
    }

    public void HealtUpdate(string text)
    {
        healt.GetComponentsInChildren<Text>()[1].text = text;
    }


    public void ScoresUpdate(string text)
    {
        score.text = text;
        if (int.Parse(text) >= int.Parse(score.text))
        {
            highScore.text = text;
        }
    }
}