using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.Events;

/// <summary>
/// sHIP GAME BUILDING PART 1
/// </summary>
public class Ship : EventInvokerInt
{
    //Adding bULLET
    [SerializeField]
    GameObject bulletPrefab;

    // thurst dir , using DMA here rather than doing it every time needed
    Vector2 thrustDirection = new Vector2(1, 0);
    // thrust magnitude
    const float thrustForce = 1f;
    // var to call rigid 2d 
    Rigidbody2D R;
    //declaring const for rotate degree
    const float RotateDegreePerSecond = 180;

    //health
    int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        R = GetComponent<Rigidbody2D>();
        //adding event invokers for events
        //game over
        // Event.Add(EventName.GameOverEvent, new GameOverEvent());
        // EventManager.AddInvoker(EventName.GameOverEvent, this);
        //space ship dead
        // Event.Add(EventName.DeadEvent, new DeadEvent());
        // EventManager.AddInvoker(EventName.DeadEvent, this);

    }

    // Update is called once per frame
    void Update()
    {
        FixedUpdate();
        // calculate rotation amount and apply rotation 
        float rotationInput = Input.GetAxis("Rotate");  //getting input
        if (rotationInput != 0)
        {
            float rotationAmount = RotateDegreePerSecond * Time.deltaTime;  //rotation amaount

            if (rotationInput < 0)
            {
                //direction
                rotationAmount *= -1;
            }

            transform.Rotate(Vector3.forward, rotationAmount);

            // change thrust direction to match ship rotation
            float zAxis = transform.eulerAngles.z * Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(zAxis);
            thrustDirection.y = Mathf.Sin(zAxis);
        }
        //if left CTRL is pressed
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            //play bullet shot sound
            AudioManager.Play(AudioClipName.BulletShot);

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            //bullet.transform.position = transform.position;
            // Get the Bullet component attached to the bullet object.
            Bullet bulletComponent = bullet.GetComponent<Bullet>();
            // Call the ApplyForce method with the thrustDirection.
            bulletComponent.ApplyForce(thrustDirection);
        }
    }
    /// <summary>
    /// To aplly force on the ship
    /// </summary>
    void FixedUpdate()
    {
        if(Input.GetAxis("Thrust") != 0){
            R.AddForce(thrustForce * thrustDirection, ForceMode2D.Force);
        }
    }
    /// <summary>
    /// When aestroid gets collided with space ship
    /// </summary>
    /// <param name="col"></param>
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision detected with: " + col.gameObject.name);
        if (col.gameObject.CompareTag("Aestroid"))
        {
            //play ship hit sound
            AudioManager.Play(AudioClipName.ShipHit);
            // Aestroid aestroid;
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        health--;
        //AudioManager.Play(AudioClipName.PlayerDamage);
        if (health <= 0)
        {
            //Event[EventName.DeadEvent].Invoke(0);
            //EventManager.AddInvoker(EventName.DeadEvent, 0);
            Destroy(gameObject);
        }
    }


}
