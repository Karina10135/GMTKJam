using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int points;
    public Text scoreText;

    public static ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = this;
        
    }

    public void AddPoints()
    {
        points--;
        scoreText.text = points.ToString();
    }

    public void SubtractPoints()
    {
        points--;
        scoreText.text = points.ToString();

    }
}
