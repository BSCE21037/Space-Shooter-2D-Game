using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// Bullet logic implementation
/// </summary>
public class Bullet : MonoBehaviour
{
    //timer fields
    const float LifeSeconds = 1;
    Timer deathTimer;
    // Start is called before the first frame update
    void Start()
    {
        //add timer component
        deathTimer = gameObject.AddComponent<Timer>();
        //set the time duration
        deathTimer.Duration = LifeSeconds;
        //run the timer
        deathTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if(deathTimer.Finished == true)
        {
            Destroy(gameObject);
        }
    }

    public void ApplyForce(Vector2 vec)
    {
        const int mag = 5;
        GetComponent<Rigidbody2D>().AddForce(vec * mag, ForceMode2D.Impulse);

    }
}
