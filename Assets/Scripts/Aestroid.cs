using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;
//using static EventName;

/// <summary>
/// Aestroid spawining script
/// </summary>
public class Aestroid : MonoBehaviour
{
    [SerializeField]
    Sprite Aestroid_1;
    [SerializeField]
    Sprite Aestroid_2;
    [SerializeField]
    Sprite Aestroid_3;
    
    void Start(){
        
    }


    public void Initialize(Direction dir, Vector3 pos)
    {
        // set asteroid position
        transform.position = pos;
        // apply impulse force to get game object moving
        
        //angle 0 to 360 deg
        float angle;
        float randomAngle = Random.value * 30f * Mathf.Deg2Rad;

        if(dir == Direction.Up)
        {
            angle = 75 * Mathf.Deg2Rad * randomAngle;
        }
        else if (dir == Direction.Left)
        {
            angle = 165 * Mathf.Deg2Rad * randomAngle;
        }
        else if(dir == Direction.Down)
        {
            angle = 255 * Mathf.Deg2Rad * randomAngle;
        }
        else
        {
            angle = -15 * Mathf.Deg2Rad * randomAngle;
        }

        StartMoving(angle);
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int spriteNum = Random.Range(0, 3);
        if (spriteNum < 1)
        {
            spriteRenderer.sprite = Aestroid_1;
        }
        else if (spriteNum < 2)
        {
            spriteRenderer.sprite = Aestroid_2;
        }
        else if (spriteNum < 3)
        {
            spriteRenderer.sprite = Aestroid_3;
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        
         Debug.Log("Collision detected with: " + coll.gameObject.name);
        if (coll.gameObject.CompareTag("Bullet") || coll.gameObject.CompareTag("Ship"))
        {
            // play asteroid hit sound
            AudioManager.Play(AudioClipName.AsteroidHit);
            // destroy bullet
            if (coll.gameObject.CompareTag("Bullet")){
                HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
                hud.UpdateScore(10);
                Destroy(coll.gameObject);
            }

            if (coll.gameObject.CompareTag("Ship"))
            {
                HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
                hud.UpdateScore(-5);
            }
            
            // destroy or split as appropriate
            if (transform.localScale.x < 0.5f)
            {
                Destroy(gameObject);
            }
            else
            {
                //cutting astroids into half
                Vector3 vec = transform.localScale;
                vec.x = vec.x / 2;
                vec.y = vec.y / 2;
                transform.localScale = vec;
                CircleCollider2D coll2 = gameObject.GetComponent<CircleCollider2D>();
                float rad = coll2.radius / 2;
                coll2.radius = rad;
                // clone twice and destroy original
                GameObject newAsteroid = Instantiate<GameObject>(gameObject, transform.position, Quaternion.identity);
                newAsteroid.GetComponent<Aestroid>().StartMoving(Random.Range(0, 2 * Mathf.PI));
                newAsteroid = Instantiate<GameObject>(gameObject, transform.position, Quaternion.identity);
                newAsteroid.GetComponent<Aestroid>().StartMoving(Random.Range(0, 2 * Mathf.PI));
                Destroy(gameObject);
            }
            
        }

    }

    public void StartMoving(float angle)
    {
        // apply impulse force to get asteroid moving
        //impulse range values
        const float minImpulse = 1.0f;
        const float maxImpulse = 3.0f;
        //Vector 2 dir as this is a 2d game
        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        //magnitude should be random between the ranges 
        float magnitude = Random.Range(minImpulse, maxImpulse);
        //now finally using the physics impulse on the aestroids
        GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
    }
}
