using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour
{

    public float dampTime = 1f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    private float offset;

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
           
            Vector3 point = Camera.main.WorldToViewportPoint(target.position);
            if (Input.GetKey(KeyCode.W))
            {
                offset = 0.3f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                offset = 0.7f;
            }
            else
            {
                offset = 0.5f;
            }

            Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, offset, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }

    }
}