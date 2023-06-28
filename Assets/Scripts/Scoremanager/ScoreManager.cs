using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Intializing score for collectable
    private int _score = 0;
    // Intializing Test mesh pro component
    private TextMeshProUGUI _scoreText;
    void Awake()
    {
        // Getting the Component
        _scoreText = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        //Calling for intialstate of the score
        RefreshUI();
    }
    //function to refresh the score in UI
    private void RefreshUI()
    {
        _scoreText.text = "Score : " + _score;
    }
    // Method to get the score for each collectables
    public void incrementScore(int incrementScore)
    {
        // incrementing the score on collection of objects
        _score += incrementScore;
        //updating the UI after the key is collected
        RefreshUI();
    }
}
