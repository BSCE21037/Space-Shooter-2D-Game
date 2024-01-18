using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0; //freeze the game

    }

    public void HandleResumeButtonOnClickEvent()
    {
        //AudioManager.Play(AudioClipName.Click);

        Time.timeScale = 1; //unfreeze the game
        SceneManager.UnloadSceneAsync("PauseMenu");
    }


    public void HandleQuitButtonOnClickEvent()
    {
        //AudioManager.Play(AudioClipName.Click);

        Time.timeScale = 1; //unfreeze the game
        Destroy(gameObject);
        SceneManager.LoadScene("MainMenu");
    }


    
}
