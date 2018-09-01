﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float stepSpeed;
    public Transform[] wayPoints;
    public Transform to;
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
            Destroy(gameObject);

        }
        else
        {
            currentPoint++;
            to = wayPoints[currentPoint];
        }

    }

}
