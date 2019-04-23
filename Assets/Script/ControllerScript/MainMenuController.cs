using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {
    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private Text highScore;

    [SerializeField]
    private Sprite[] players;

    [SerializeField]
    private Image player;

    [SerializeField]
    private GameObject btnMute;

    [SerializeField]
    private GameObject btnSpeaker;

    public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
        
    }
    public void HighScorePanel()
    {
        gameOverPanel.SetActive(true);
        highScore.text = PlayerPrefs.GetInt("highScore", 0) + " Year";

        if(PlayerPrefs.GetInt("highScore", 0) == 0)
        {
            player.sprite = players[0];
        }
        if (PlayerPrefs.GetInt("highScore", 0) >= 1)
        {
            player.sprite = players[1];
        }
        if (PlayerPrefs.GetInt("highScore", 0) >= 4)
        {
            player.sprite = players[2];
        }
        if (PlayerPrefs.GetInt("highScore", 0) >= 6)
        {
            player.sprite = players[3];
        }
        if (PlayerPrefs.GetInt("highScore", 0) >= 12)
        {
            player.sprite = players[4];
        }
        if (PlayerPrefs.GetInt("highScore", 0) >= 19)
        {
            player.sprite = players[5];
        }
        if (PlayerPrefs.GetInt("highScore", 0) >= 25)
        {
            player.sprite = players[6];
        }
        if (PlayerPrefs.GetInt("highScore", 0) >= 36)
        {
            player.sprite = players[7];
        }
        if (PlayerPrefs.GetInt("highScore", 0) >= 50)
        {
            player.sprite = players[8];
        }
    }

    public void Cancel()
    {
        gameOverPanel.SetActive(false);
    }

    public void mute()
    {
        AudioListener.pause = true;
        btnMute.SetActive(true);
        btnSpeaker.SetActive(false);
    }

    public void sound()
    {
        AudioListener.pause = false;
        btnSpeaker.SetActive(true);
        btnMute.SetActive(false);
    }
    // Use this for initialization
    void Start () {
		
	}
	// Update is called once per frame
	void Update () {
        if(AudioListener.pause == true)
        {
            btnMute.SetActive(true);
            btnSpeaker.SetActive(false);
        }
        if (AudioListener.pause == false)
        {
            btnSpeaker.SetActive(true);
            btnMute.SetActive(false);
        }
    }
}
