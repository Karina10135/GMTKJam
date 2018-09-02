using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Moon;
    public GameObject Barrel;
    public GameObject RockSpawner;
    public GameObject PausePanel;
    public bool isPaused;
    public bool done;
    public static GameManager gm;

    private void Start()
    {
        gm = this;
        isPaused = false;
    }
    public void Update()
    {
        if (done) { return; }
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    PauseGame();
            
        //}
    }
    public void PauseGame()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }

        if (PausePanel != null)
        {
            PausePanel.SetActive(isPaused);

        }
    }

    public void Death()
    {
        done = true;
        Barrel.GetComponent<BarrelControl>().Death();
        ScoreManager.scoreManager.EndResult();
    }
}
