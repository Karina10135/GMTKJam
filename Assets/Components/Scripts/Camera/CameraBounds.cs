using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour {

    public Transform minBound;
    public Transform maxBound;

    float vertEdgeDist;
    float horizEdgeDist;

    // Use this for initialization
    void Start () {
        
        vertEdgeDist = Camera.main.orthographicSize;
        horizEdgeDist = Camera.main.orthographicSize * Screen.width / Screen.height;



    }
	
	// Update is called once per frame
	void LateUpdate () {
        var v3 = transform.position;
        v3.x = Mathf.Clamp(v3.x, minBound.position.x + horizEdgeDist, maxBound.position.x - horizEdgeDist);
        v3.y = Mathf.Clamp(v3.y, minBound.position.y + vertEdgeDist, maxBound.position.y - vertEdgeDist);
        transform.position = v3;
    }
}
