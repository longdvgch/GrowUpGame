using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour {

    public static GamePlayController instance;
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip  dieClip;

    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private GameObject Score;

    private void Awake()
    {
        MakeInstance();
    }
    public void btnRestart()
    {
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene("GamePlay");
    }

    public void btnBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
     
    public void PlayerDiePanel()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(dieClip);        
        gameOverPanel.SetActive(true);    
    }
    public void startSroce()
    {
        Score.SetActive(true);
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}

