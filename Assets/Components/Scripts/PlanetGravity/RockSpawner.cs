using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject moon;
    public GameObject asteroidPrefab;
    public Transform[] spawnPoints;

    [System.Serializable]
    public class WayPointGroup
    {
        public string waypointGroup;
        public Transform[] wayPoints;
        
    }

    public WayPointGroup[] ways;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AsteroidCreate();
        }
    }

    

    public void AsteroidCreate()
    {
        int n = Random.RandomRange(0, spawnPoints.Length);
        var rock = Instantiate(asteroidPrefab, spawnPoints[n]);
        var asteroid = rock.GetComponent<Asteroid>();

        asteroid.wayPoints = new Transform[ways[n].wayPoints.Length];


        for(int i = 0; i < ways[n].wayPoints.Length; i++)
        {
            asteroid.wayPoints[i] = ways[n].wayPoints[i];
        }

        rock = null;
    }



}
