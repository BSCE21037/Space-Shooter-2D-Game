using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// gets and displays the high score
/// </summary>
public class HighScoreMenu : MonoBehaviour
{

    /// <summary>
    /// text message
    /// </summary>
    
    [SerializeField]
    TextMeshProUGUI textMessage;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0; //freeze the game

        if(PlayerPrefs.HasKey("HighScore"))
        {
            textMessage.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            textMessage.text = "Looks like you haven't played yet!";
        }
    }

    // Update is called once per frame
    public void HandleQuitButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);

        Time.timeScale = 1; //unfreeze the game
        SceneManager.LoadScene("MainMenu");
    }
}
