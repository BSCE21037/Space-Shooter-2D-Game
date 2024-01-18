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
                SceneManager.LoadScene("HighScoreMenu");
                break;
            case MenuName.Gameplay:
                //close the main menu scene before opening the gameplay scene
                //SceneManager.UnloadSceneAsync("MainMenu");

                //close the main menu canvas before opening the gameplay menu
                GameObject mmc2 = GameObject.Find("MainMenuCanvas");
                if (mmc2 != null)
                {
                    mmc2.SetActive(false);
                }
                //Fix: Display 1 No Cameras Rendering
                SceneManager.LoadScene("Gameplay");
                break;
            case MenuName.Pause:
                //instantiates the pause menu prefab at the moment
                //pause the time
                //Time.timeScale = 0;
                SceneManager.LoadScene("PauseMenu");
                break;
        }
    }   
}
