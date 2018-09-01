using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject moon;
    public GameObject asteroidPrefab;
    public Transform[] spawnPoints;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AsteroidCreate();
        }
    }

    public void AsteroidCreate()
    {
        int i = Random.RandomRange(0, spawnPoints.Length);
        var rock = Instantiate(asteroidPrefab, spawnPoints[i]);
        rock.GetComponent<FauxGravityBody>().attractor = moon.GetComponent<FauxGravityAttractor>();
        rock = null;
    }



}
