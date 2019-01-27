using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatScoreScript : MonoBehaviour
{
    public Text scoreText;
    public int score;
    void Start()
    {
        score = 0;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Cats: " + score;
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
}
