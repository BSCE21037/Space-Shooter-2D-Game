using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    /// <summary>
    /// Switch between menus accordingly
    /// </summary>
    // Start is called before the first frame update
    public static void GoToMenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.HighScore:
                //close the main menu canvas before opening the high score menu
                GameObject mmc = GameObject.Find("MainMenuCanvas");
                if(mmc != null)
                {
                    mmc.SetActive(false);
                }
                Object.Instantiate(Resources.Load("HighScoreMenu"));
                break;
            case MenuName.Gameplay:
                Debug.Log("Play button clicked");
                SceneManager.LoadScene("Gameplay");
                break;
            case MenuName.Pause:
                //instantiates the pause menu prefab at the moment
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
        }
    }   
}
