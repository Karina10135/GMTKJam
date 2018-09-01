using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelControl : MonoBehaviour
{
    public GameObject player;
    public Transform left;
    public Transform right;
    public float moveSpeed;
    public float maxSpeed;
    public float minDistance;
    public float maxDistance;

    float push;

    bool moving;
    float orgSpeed;
    Vector3 moveDir;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        moving = false;
        orgSpeed = moveSpeed;
    }

    private void FixedUpdate()
    {
        moveDir = new Vector3(push, 0, 0).normalized;
        rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);
        PushBarrel();

        //if (moving)
        //{
        //    rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);

        //}
    }

    private void Update()
    {
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(left.position, right.position);
    }

    public void PushBarrel()
    {
        var centre = transform.position;
        var targetPos = player.transform.position;
        var leftDst = Vector3.Distance(left.position, targetPos);
        var rightDst = Vector3.Distance(right.position, targetPos);
        
        if(leftDst > maxDistance && rightDst > maxDistance) //if its more than maxdistance
        {
            moveSpeed = orgSpeed;
            moving = false;
        }

        if (leftDst < maxDistance && leftDst > minDistance)
        {
            
            push = 1;
            moving = true;
            if(leftDst < .5 && leftDst > .4)
            {
                if (moveSpeed < maxSpeed)
                {
                    moveSpeed += Time.deltaTime;
                }
                else
                {
                    moveSpeed = maxSpeed;
                }
            }
            else
            {
                if (moveSpeed > orgSpeed)
                {
                    moveSpeed -= Time.deltaTime;
                }
                else
                {
                    moveSpeed = orgSpeed;
                }
            }

            
        }

        if (rightDst < maxDistance && rightDst > minDistance)
        {
            push = -1;
            moving = true;

            //if (leftDst < .5 && leftDst > .4)
            //{

            //}

            if (moveSpeed < maxSpeed)
            {
                moveSpeed += Time.deltaTime;
            }
            else
            {
                moveSpeed = maxSpeed;
            }
        }

        //0.7
        //0.3 unitil too close.

    }



}
