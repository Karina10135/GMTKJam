using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 15;
    private Vector3 moveDir;
    Rigidbody rb;

    bool moved;
    bool right;
    bool playerInput;
    Transform target;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = Camera.main.transform;
    }

    private void Update()
    {

        //transform.rotation = Quaternion.EulerAngles(0, 0, transform.rotation.z);

        if (Input.GetAxis("Horizontal") != 0)
        {
            playerInput = true;
            moved = true;
        }
        else
        {
            playerInput = false;
        }

        if (!moved) { return; }

        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0).normalized;

        if (playerInput)
        {
            moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0).normalized;
            return;
        }

        if (right)
        {
            moveDir = new Vector3(1, 0, 0).normalized;
        }
        else
        {
            moveDir = new Vector3(-1, 0, 0).normalized;
        }
    }

    public void Direction(bool state)
    {
        right = state;
        print(right);
    }


    private void FixedUpdate()
    {
        if (!moved) { return; }
        rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);
    }
}
