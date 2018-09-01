using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRotation : MonoBehaviour
{
    //public GameObject Barrel;
    float smoothTime;
    private void Update()
    {
    }

    public void RotateWorld(bool rotation, float speed)
    {
        float smooth = Time.deltaTime * smoothTime;

        if (rotation)
        {
            transform.RotateAround(transform.position, speed * Time.deltaTime);

        }
        else
        {
            transform.RotateAround(transform.position, -speed * Time.deltaTime);

        }
    }

}
