using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public float movePower;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        rb.AddRelativeForce(new Vector2(Input.GetAxis("Horizontal") * movePower, 0));
    }

}
