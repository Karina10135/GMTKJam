using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject moon;
    public GameObject[] asteroidPrefabs;
    public Transform[] spawnPoints;

    [System.Serializable]
    public class WayPointGroup
    {
        public string waypointGroup;
        public Transform[] wayPoints;
        
    }

    public WayPointGroup[] ways;


    public void Start()
    {
        StartCoroutine(StartTime());    
    }

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
        int a = Random.RandomRange(0, asteroidPrefabs.Length);
        var rock = Instantiate(asteroidPrefabs[a], spawnPoints[n]);
        var asteroid = rock.GetComponent<Asteroid>();

        asteroid.wayPoints = new Transform[ways[n].wayPoints.Length];


        for(int i = 0; i < ways[n].wayPoints.Length; i++)
        {
            asteroid.wayPoints[i] = ways[n].wayPoints[i];
        }

        rock = null;
    }

    IEnumerator StartTime()
    {
        yield return new WaitForSeconds(10);
        AsteroidCreate();
    }

}
