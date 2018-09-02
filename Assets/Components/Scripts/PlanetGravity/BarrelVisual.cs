using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelVisual : MonoBehaviour
{
    public BarrelRotation moon; 

    public void Barrel(bool positive, float speed)
    {
        if (GameManager.gm.isPaused) { return; }
        if (GameManager.gm.done) { return; }
        if (positive)
        {
            transform.RotateAroundLocal(Vector3.back, speed * Time.deltaTime);


        }
        else
        {
            transform.RotateAroundLocal(Vector3.back, -speed * Time.deltaTime);
        }

        moon.RotateWorld(positive, speed);

    }
}
