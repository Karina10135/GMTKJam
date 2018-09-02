using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    
    public float stepSpeed;
    public Transform[] wayPoints;
    public Transform to;
    private float lerpTime = 5;
    private float currentLerpTime = 0;
    public bool destroy;
    int currentPoint;


    private void Start()
    {
        currentPoint = 0;
        to = wayPoints[currentPoint];
    }

    public void Update()
    {

        if (to != null)
        {
            float step = stepSpeed * Time.deltaTime;
            
            transform.position = Vector3.MoveTowards(transform.position, to.position, step);
            transform.RotateAroundLocal(Vector3.back, stepSpeed * Time.deltaTime);

        }

        if(transform.position == to.position)
        {
            NextMove();
        }


    }


    public void NextMove()
    {
        if(to == wayPoints[wayPoints.Length - 1])
        {
            if (destroy)
            {
                Destroy(gameObject);

            }
            else
            {
                currentPoint = 0;
                to = wayPoints[currentPoint];
            }

        }
        else
        {
            currentPoint++;
            to = wayPoints[currentPoint];
        }

        currentLerpTime = 0;

    }

}
