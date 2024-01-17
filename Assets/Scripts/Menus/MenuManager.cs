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
                //load another camera
                //SceneManager.LoadScene("Gameplay", LoadSceneMode.Additive);
                // SceneManager.SetActiveScene(SceneManager.GetSceneByName("Gameplay"));

                //SceneManager.SetActiveScene(SceneManager.GetSceneByName("Gameplay"));
                break;
            case MenuName.Pause:
                //instantiates the pause menu prefab at the moment
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
        }
    }   
}
