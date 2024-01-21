using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    Timer timer;
    void Start()
    {
        
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 3;
        timer.Run();

    }

    // Update is called once per frame
    void Update()
    {
        if(timer.Finished)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
