using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelControl : MonoBehaviour
{
    public GameObject player;
    public Transform left;
    public Transform right;
    public float pushPower;
    public float moveSpeed;
    public float minDistance;
    public float maxDistance;
    Vector3 moveDir;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        moveDir = new Vector3(pushPower, 0, 0).normalized;
        rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);
        print(moveDir);
    }

    private void Update()
    {
        PushBarrel();
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
        
        if(leftDst > minDistance)
        {

        }

        //0.7
        //0.3 unitil too close.

    }



}
