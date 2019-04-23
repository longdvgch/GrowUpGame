using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed;
    private Rigidbody2D myBody;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        enemySpeed = Spawner.instance.enemySpeed;
        transform.position += new Vector3(0, -enemySpeed * Time.deltaTime, 0);

    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "DestroySpawner")
        {
            Destroy(gameObject);
        }
    }
}
  
