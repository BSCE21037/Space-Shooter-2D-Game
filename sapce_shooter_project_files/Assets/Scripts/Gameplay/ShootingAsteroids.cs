using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// Game Manager
/// </summary>
public class ShootingAsteroids : MonoBehaviour
{

    #region Fields

    [SerializeField]
    GameObject hud;

    HUD hudScript;

    int currentScore;

    public static int image = 0;


    #endregion
    // Start is called before the first frame update
    void Start()
    {
        //add this invoker to the dictionary
        //EventManager.AddListener(EventName.GameOverEvent, HandleGameOverEvent);
        if (hud == null)
        {
            Debug.Log("HUD is null");
        }
        else{
            hudScript = hud.GetComponent<HUD>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseMenu.pauseOn == 0){
            if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "Gameplay")
            {
                //pauseOn = 1;
                //quit the game
                MenuManager.GoToMenu(MenuName.Pause);
                AudioManager.Play(AudioClipName.PauseGame);
                //pauseOn = 0;
            }
            //currentScore = hudScript.Score;
        }
        
        
    }

    public void HandleGameOverEvent(int points)
    {
        Debug.Log("Game Over Event");
        image = 1;
        currentScore = points;
        EndGame();
        // image = 0;
    }

    void EndGame()
    {
        SetHighScore();
        MenuManager.GoToMenu(MenuName.HighScore);
        AudioManager.Play(AudioClipName.GameOver);
    }

    void SetHighScore()
    {
        
		
		if (PlayerPrefs.HasKey("HighScore"))
        {
            Debug.Log("High Score already exists");
            Debug.Log("Current Score: " + currentScore);
			if (currentScore > PlayerPrefs.GetInt("HighScore"))
            {
                Debug.Log("New High Score");
				PlayerPrefs.SetInt("HighScore", currentScore);
                PlayerPrefs.Save();
			}
		}
        else
        {
            //Debug.Log("High Score saved for the first time");
			PlayerPrefs.SetInt("HighScore", currentScore);
            PlayerPrefs.Save();
        }
    }

}

