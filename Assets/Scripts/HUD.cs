using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// HUD for the game
/// </summary>

public class HUD : MonoBehaviour
{

    #region  Fields


    //score
    [SerializeField]
    TextMeshProUGUI scoreText;
    int score = 0;

    //lives
    [SerializeField]
    TextMeshProUGUI livesText;
    int lives = 3;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int lives)
    {
        this.lives = lives;
        livesText.text = "Lives: " + lives;
    }

}
