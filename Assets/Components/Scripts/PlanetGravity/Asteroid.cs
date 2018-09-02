using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    
    public float stepSpeed;
    public Transform[] wayPoints;
    public Transform to;
    private float lerpTime = 5;
    private float currentLerpTime = 0;
    public ParticleSystem deathVFX;
    public bool destroy;
    int currentPoint;


    private void Start()
    {
        currentPoint = 0;
        to = wayPoints[currentPoint];
    }

    public void Update()
    {

        if (to != null)
        {
            float step = stepSpeed * Time.deltaTime;
            
            transform.position = Vector3.MoveTowards(transform.position, to.position, step);
            transform.RotateAroundLocal(Vector3.back, stepSpeed * Time.deltaTime);

        }

        if(transform.position == to.position)
        {
            NextMove();
        }


    }


    public void NextMove()
    {
        if(to == wayPoints[wayPoints.Length - 1])
        {
            if (destroy)
            {
                Destroy(gameObject);

            }
            else
            {
                currentPoint = 0;
                to = wayPoints[currentPoint];
            }

        }
        else
        {
            currentPoint++;
            to = wayPoints[currentPoint];
        }

        currentLerpTime = 0;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.audioManager.FadeSound();
            Transform pos = other.gameObject.transform;
            //other.GetComponent<FauxGravityBody>().attractor = GameManager.gm.Moon.GetComponent<FauxGravityAttractor>();
            GameManager.gm.Barrel.GetComponent<BarrelControl>().Death();
            //other.GetComponent<PlayerController>().enabled = false;
            Destroy(other.gameObject);
            if (deathVFX != null)
            {
                var blood = Instantiate(deathVFX, pos);
                blood.transform.SetParent(null);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.audioManager.FadeSound();
            GameObject p = other.gameObject.GetComponentInParent<FauxGravityBody>().gameObject;
            p.GetComponent<FauxGravityBody>().attractor = GameManager.gm.Moon.GetComponent<FauxGravityAttractor>();
            GameManager.gm.Barrel.GetComponent<BarrelControl>().Death();
            p.GetComponent<PlayerController>().enabled = false;
            Destroy(other.gameObject);
            Transform pos = other.gameObject.transform;

            //if (deathVFX != null)
            //{
            //    var blood = Instantiate(deathVFX, pos);
            //    blood.transform.SetParent(null);
            //}
        }
    }

}
