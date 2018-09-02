using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl2D : MonoBehaviour
{
    public float playerSpeed;
    BarrelVisual barrel;
    Vector2 moveDir;

    public void Start()
    {
        barrel = GetComponentInParent<BarrelVisual>();
    }

    private void Update()
    {
        

        MoveDirection();
    }

    public void MoveDirection()
    {
        moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), 0).normalized;

        if (moveDir.x < 0)
        {
            transform.RotateAround(barrel.gameObject.transform.position, Vector3.forward, playerSpeed * Time.deltaTime);

        }
        if (moveDir.x > 0)
        {
            transform.RotateAround(barrel.gameObject.transform.position, Vector3.forward, -playerSpeed * Time.deltaTime);

        }
    }


}
