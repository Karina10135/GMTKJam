using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelVisual : MonoBehaviour
{

    public void Barrel(bool positive, float speed)
    {
        if (positive)
        {
            //transform.RotateAround(transform.position, speed * Time.deltaTime);
            transform.RotateAroundLocal(Vector3.back, speed * Time.deltaTime);

        }
        else
        {
            //transform.RotateAround(transform.position, -speed * Time.deltaTime);
            transform.RotateAroundLocal(Vector3.back, -speed * Time.deltaTime);

        }
    }
}
