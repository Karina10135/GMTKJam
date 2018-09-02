using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelControl : MonoBehaviour
{
    public GameObject player;
    public GameObject barrelSprite;
    public Transform left;
    public Transform right;
    public float moveSpeed;
    public float maxSpeed;
    public float minDistance;
    public float maxDistance;

    public BarrelRotation barrelRotation;

    bool dead;
    bool moved;
    float push;
    bool positive;
    bool moving;
    float orgSpeed;
    Vector3 moveDir;
    Rigidbody rb;

    private void Start()
    {

        //rb = GetComponent<Rigidbody>();

        moving = false;
        orgSpeed = moveSpeed;
    }

    private void FixedUpdate()
    {
        if (dead) { return; }
        if(rb != null)
        {
            moveDir = new Vector3(push, 0, 0).normalized;
            rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);
        }

        PushBarrel();

        if (moved)
        {
            barrelSprite.GetComponent<BarrelVisual>().Barrel(positive, moveSpeed);

        }
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
            if (!moved) { return; }
            moveSpeed = orgSpeed;
            moveSpeed -= Time.deltaTime;
            moving = false;
            barrelRotation.RotateWorld(positive, moveSpeed);


        }

        if (leftDst < maxDistance && leftDst > minDistance)
        {
            moved = true;
            push = 1;
            moving = true;


            if(leftDst < .6 && leftDst > .3) //Moving left
            {
                barrelRotation.RotateWorld(false, moveSpeed);

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

            positive = false;
            barrelRotation.RotateWorld(positive, moveSpeed);
        }

        if (rightDst < maxDistance && rightDst > minDistance) //Moving right
        {
            moved = true;
            push = -1;
            moving = true;

            if (rightDst < .6 && rightDst > .3) //Moving left
            {
                //barrelRotation.RotateWorld(true, moveSpeed);

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

            positive = true;
            barrelRotation.RotateWorld(positive, moveSpeed);
        }

        //0.7
        //0.3 unitil too close.

    }

    public void Death()
    {
        dead = true;
    }



}
