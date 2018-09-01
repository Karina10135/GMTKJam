using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelVisual : MonoBehaviour
{

    public void Barrel(bool positive, float speed)
    {
        if (positive)
        {
            transform.RotateAroundLocal(Vector3.back, speed * Time.deltaTime);

        }
        else
        {
            transform.RotateAroundLocal(Vector3.back, -speed * Time.deltaTime);

        }
    }
}
