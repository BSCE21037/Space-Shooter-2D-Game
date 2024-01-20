using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    static public int pauseOn;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0; //freeze the game
        pauseOn = 1;
    }

    public void HandleResumeButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);

        Time.timeScale = 1; //unfreeze the game
        Destroy(gameObject);
        pauseOn = 0;
        //SceneManager.UnloadSceneAsync("PauseMenu");
    }


    public void HandleQuitButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);

        Time.timeScale = 1; //unfreeze the game
        Destroy(gameObject);
        pauseOn = 0;
        SceneManager.LoadScene("MainMenu");
    }
}
