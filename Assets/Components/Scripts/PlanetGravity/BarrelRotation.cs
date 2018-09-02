using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRotation : MonoBehaviour
{
    public GameObject player;
    

    public void RotateWorld(bool rotation, float speed)
    {

        if (rotation)
        {
            player.GetComponent<PlayerController>().Direction(true);
            transform.RotateAround(transform.position, speed * Time.deltaTime);
            ScoreManager.scoreManager.AddPoints();

        }
        else
        {
            player.GetComponent<PlayerController>().Direction(false);
            transform.RotateAround(transform.position, -speed * Time.deltaTime);
            ScoreManager.scoreManager.SubtractPoints();

        }

    }



}
