using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRotation : MonoBehaviour
{

    public void RotateWorld(bool rotation, float speed)
    {
        //if (GameManager.gm.isPaused) { return; }
        //if (GameManager.gm.done) { return; }

        if (rotation)
        {
            transform.RotateAround(transform.position, speed * Time.deltaTime);
            ScoreManager.scoreManager.AddPoints();

        }
        else
        {
            transform.RotateAround(transform.position, -speed * Time.deltaTime);
            ScoreManager.scoreManager.SubtractPoints();

        }

    }



}
