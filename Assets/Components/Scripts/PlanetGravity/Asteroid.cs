using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject barrel;
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
                GameManager.gm.RockSpawner.GetComponent<RockSpawner>().AsteroidCreate();
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
            GameManager.gm.Death();
            other.gameObject.GetComponent<PlayerControl2D>().enabled = false;
            other.gameObject.transform.SetParent(null);
            var magnitude = 5000;
            var force = transform.position - other.transform.position;
            force.Normalize();
            //other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 500);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(-force * magnitude);

            //Destroy(other.gameObject);
            if (deathVFX != null)
            {
                var blood = Instantiate(deathVFX, pos);
                blood.transform.SetParent(null);

            }
        }

        //if (other.gameObject.CompareTag("Barrel"))
        //{
        //    print("Barrel");
        //    AudioManager.audioManager.FadeSound();
        //    Transform pos = other.gameObject.transform;
        //    GameManager.gm.Death();

        //    var magnitude = 5000;
        //    var force = transform.position - other.transform.position;
        //    force.Normalize();
        //    var hit = Instantiate(barrel, other.transform);
        //    hit.transform.parent = null;
        //    Destroy(other.gameObject);
        //    hit.gameObject.GetComponent<Rigidbody2D>().AddForce(-force * magnitude);

        //    if (deathVFX != null)
        //    {
        //        var blood = Instantiate(deathVFX, pos);
        //        blood.transform.SetParent(null);

        //    }
        //}

    }

    


}
