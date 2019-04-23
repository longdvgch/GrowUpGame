using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class line : MonoBehaviour {

    public float lineSpeed;
    private Rigidbody2D myBody;


    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start()
    {
       //starTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        _lineMove();


    }
    void _lineMove()
    {
        Vector3 temp = transform.position;
        temp.y -= lineSpeed * Time.deltaTime;
        transform.position = temp;
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "DestroySpawner")
        {
            Destroy(gameObject);
        }
    }
    //public void OnGUI()
    //{
    //    string y = ((int)(playerScore / 365)).ToString();
    //    string d = (playerScore % 60).ToString("f2");
    //    ScoreText.text = y + " Year " + d + " Day";
    //}
}
