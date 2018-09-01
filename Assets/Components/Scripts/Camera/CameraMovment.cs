using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour {

    public int scrollEdgeDistance = 50; // distance from edge scrolling starts
    public int scrollSpeed = 5;

    private int screenWidth;
    private int screenHeight;

	// Use this for initialization
	void Start () {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.mousePosition.x > screenWidth - scrollEdgeDistance)
        {
            //transform.position.x += scrollSpeed * Time.deltaTime; // move on +X axis
            transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
        }
        if (Input.mousePosition.x < 0 + scrollEdgeDistance)
        {
            //transform.position.x -= scrollSpeed * Time.deltaTime; // move on -X axis
            transform.Translate(Vector3.right * -scrollSpeed * Time.deltaTime);
        }
        if (Input.mousePosition.y > screenHeight - scrollEdgeDistance)
        {
            //transform.position.y += scrollSpeed * Time.deltaTime; // move on +Y axis
            transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
        }
        if (Input.mousePosition.y < 0 + scrollEdgeDistance)
        {
            //transform.position.y -= scrollSpeed * Time.deltaTime; // move on -Y axis
            transform.Translate(Vector3.up * -scrollSpeed * Time.deltaTime);
        }
    }
}
