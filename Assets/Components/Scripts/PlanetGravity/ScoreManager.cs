using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int points;
    public Text scoreText;
    public Text resultsText;
    public GameObject resultsPanel;
    public int pointTrigger;

    public static ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = this;
        scoreText.text = points.ToString() + "m";
    }

    public void Update()
    {
        
    }

    public void AddPoints()
    {
        points++;
        scoreText.text = points.ToString() + "m";

    }

    public void SubtractPoints()
    {
        points--;
        scoreText.text = points.ToString() + "m";

    }

    public void EndResult()
    {
        if(resultsText != null) { resultsText.text = points.ToString() + " Meters"; }
        scoreText.gameObject.SetActive(false);
        resultsPanel.SetActive(true);

    }

    
}
