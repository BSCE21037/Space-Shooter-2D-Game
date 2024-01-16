using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Game Manager
/// </summary>
public class ShootingAsteroids : EventInvokerInt
{

    #region Fields

    [SerializeField]
    GameObject hud;


    #endregion
    // Start is called before the first frame update
    void Start()
    {
        //add this invoker to the dictionary
        EventManager.AddListener(EventName.GameOverEvent, HandleGameOverEvent);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //quit the game
            MenuManager.GoToMenu(MenuName.Pause);
            AudioManager.Play(AudioClipName.PauseGame);
        }
    }

    void HandleGameOverEvent(int points)
    {
        EndGame();
    }

    void EndGame()
    {
        //SetHighScore();
        MenuManager.GoToMenu(MenuName.HighScore);
        // AudioManager.Play(AudioClipName.GameOver);
    }

    // void SetHighScore()
    // {
    //     HUD hudScript = hud.GetComponent<HUD>();
    //     //get the high score
    //     int highScore = PlayerPrefs.GetInt("HighScore", 0);
    //     //get the current score
    //     int currentScore = hudScript.Score;
    //     //ichecking if we have previous high score
    //     if(PlayerPrefs.HasKey("HighScore")){
    //         if(currentScore > highScore)
    //         {
    //             //set the high score to the current score
    //             PlayerPrefs.SetInt("HighScore", currentScore);
    //             PlayerPrefs.Save();
    //         }
    //     }
    //     else{
    //         //set the high score to the current score
    //         PlayerPrefs.SetInt("HighScore", currentScore);
    //         PlayerPrefs.Save();
    //     }
    // }

}

