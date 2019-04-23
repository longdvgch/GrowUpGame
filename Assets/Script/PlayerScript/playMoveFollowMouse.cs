using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMoveFollowMouse : MonoBehaviour {

    Vector3 mousePos;
    public float moveSpeed;
    private float minX, maxX;


    // Use this for initialization


    void Start () {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        maxX = bounds.x - 0.4f;
        minX = -bounds.x + 0.4f;

        mousePos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePos = new Vector3(Mathf.Clamp(mousePos.x, minX, maxX), -2.44f, 0);
        }
        transform.position = Vector3.Lerp(transform.position, mousePos, moveSpeed * Time.deltaTime);
	}
}
