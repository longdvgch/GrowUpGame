using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public static Spawner instance;

    public float enemySpeed;
    [SerializeField]
    private GameObject[] enemys;
    [SerializeField]
    private GameObject player;
    private Animator animator;
    const string animationState = "animationState";
    public float timeDelay = 0.1f; //for the purpose of spawning at intervals, you can use what you like :)
    public float currentTime;
    public float timeSpeedUp;
    public float speedUpDelay = 10.0f;


    // Use this for initialization
    void Start()
    {
        currentTime = Time.time + timeDelay;
        timeSpeedUp = Time.time + speedUpDelay;
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MakeInstance();
        if(player != null)
        {
            randomEnemy();
        }
        


    }

    void randomEnemy()
    {
        if (Time.time > currentTime)
        {
            float[] ponit = { -2.5f, -0.8f, 0.8f, 2.5f, };
            Vector3 temp = transform.position;
            Vector3 temp1 = transform.position;
            Vector3 temp2 = transform.position;
            temp.x = ponit[Random.Range(0, 2)];
            temp1.x = ponit[Random.Range(2, 4)];
            temp2.x = ponit[Random.Range(1, 3)];
           
            GameObject selectEnemy = enemys[Random.Range(0, 4)];
            if (animator == null)
            {
                animator.enabled = false;
            }
            if (animator.GetInteger(animationState) == 2)
            {
                selectEnemy = enemys[Random.Range(4, 8)];
            }
            if (animator.GetInteger(animationState) == 3)
            {
                selectEnemy = enemys[Random.Range(6, 10)];
            }
            if (animator.GetInteger(animationState) == 4)
            {
                selectEnemy = enemys[Random.Range(8, 14)];
            }
            if (animator.GetInteger(animationState) == 5)
            {
                selectEnemy = enemys[Random.Range(11, 16)];
            }
            if (animator.GetInteger(animationState) == 6)
            {
                selectEnemy = enemys[Random.Range(15, 20)];
            }
            if (animator.GetInteger(animationState) == 7)
            {
                selectEnemy = enemys[Random.Range(18, 22)];
            }
            if (animator.GetInteger(animationState) == 8)
            {
                selectEnemy = enemys[Random.Range(22, 26)];
            }
            if (animator.GetInteger(animationState) == 9)
            {
                selectEnemy = enemys[Random.Range(26, 30)];
            }
            GameObject tempEnemy = Instantiate(selectEnemy, temp, Quaternion.identity) as GameObject;
            GameObject tempEnemy1 = Instantiate(selectEnemy, temp1, Quaternion.identity) as GameObject;
            GameObject tempEnemy2 = Instantiate(selectEnemy, temp1, Quaternion.identity) as GameObject;
            tempEnemy.GetComponent<Enemy>().enemySpeed = enemySpeed;
            tempEnemy1.GetComponent<Enemy>().enemySpeed = enemySpeed;
            tempEnemy2.GetComponent<Enemy>().enemySpeed = enemySpeed;
            //enemySpeed = speedIncrement;
            currentTime = Time.time + timeDelay;

            if (Time.time > timeSpeedUp)
            {
                enemySpeed += 0.3f;
                timeDelay -= 0.1f;
                Background.instance.scrollSpeed += 0.03f;
                timeSpeedUp = Time.time + speedUpDelay;
                if (timeDelay <= 0.1)
                {
                    timeDelay = 0.1f;
                }
            }
        }
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
