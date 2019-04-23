using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float playerScore;
    float starTime;
    public Text ScoreText;
    private Rigidbody2D player;
    private Animator animator;
    const string animationState = "animationState";
    int divisor = 365;
    public Text endScore;
    public Text highScore;
    public int hScore;



    // Use this for initialization
    void Start () {
        starTime = Time.time;
        highScore.text = "High Score: "+ PlayerPrefs.GetInt("highScore",0) + " Year";
        player = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
	void Update () {
        playerScore = Time.time - starTime;
        int d = (int)(playerScore * 10);
        int y = ((int)(d / divisor));
        if (d > divisor)
        {
            while (d > divisor)
            {
                d = d - divisor;
                y = y - 1;
                y++;
            }           
        }
        ScoreText.text = y + " Year " + d + " Day";
        endScore.text = "Your Score: " + y + " Year";
        changeAnimator(y);
        getHighScore(y);

    }

    void getHighScore(int y)
    {
        if (y > PlayerPrefs.GetInt("highScore", 0))
        {
            hScore = y;
            PlayerPrefs.SetInt("highScore", hScore);
            highScore.text = "High Score: " + hScore + " Year";
        }
    }

    void changeAnimator(int y)
    {
        if (y == 1) {
            animator.SetInteger(animationState, 2);
           
        }
         if (y >= 4){
            animator.SetInteger(animationState, 3);
            
        }
         if (y >= 6){
            animator.SetInteger(animationState, 4);
            
        }
         if (y >= 12){
            animator.SetInteger(animationState, 5);
        }
        if (y >= 19){
            animator.SetInteger(animationState, 6);
        }
        if (y >= 25){
            animator.SetInteger(animationState, 7);
            player.transform.localScale = new Vector3(0.9f, 0.9f, 1);
        }
        if (y >= 36){
            animator.SetInteger(animationState, 8);
            player.transform.localScale += new Vector3(0.9f, 0.9f, 1);
        }
        if (y >= 50){
            animator.SetInteger(animationState, 9);
            player.transform.localScale = new Vector3(0.8f, 0.8f, 1);
        }
       
    }

    public void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "enemy")
        {
            Destroy(gameObject);        
            GamePlayController.instance.PlayerDiePanel();

        }
        if (target.tag == "line")
        {
            starTime = Time.time;
            GamePlayController.instance.startSroce();
        }
    }


}
