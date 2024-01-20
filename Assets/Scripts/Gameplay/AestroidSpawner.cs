using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Spawining Aestroids
/// </summary>
public class AestroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabAestroid;

    // Start is called before the first frame update
    void Start()
    {
        //storing game object
        GameObject aestroid = Instantiate<GameObject>(prefabAestroid);
        //storing circle collider 2d of aestroid
        CircleCollider2D circleCollider2D = aestroid.GetComponent<CircleCollider2D>();
        //getting its radius
        float radius = circleCollider2D.radius;
        //destroying the copy game object
        Destroy(aestroid);

        //getting screen res by screenutils script
        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        float screenHeight = ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom;

        // right side asteroid
        aestroid = Instantiate<GameObject>(prefabAestroid);
        Aestroid script = aestroid.GetComponent<Aestroid>();
        script.Initialize(Direction.Left, new Vector2(ScreenUtils.ScreenRight + radius, ScreenUtils.ScreenBottom + screenHeight / 2));

        // top side asteroid
        aestroid = Instantiate<GameObject>(prefabAestroid);
        script = aestroid.GetComponent<Aestroid>();
        script.Initialize(Direction.Down,
            new Vector2(ScreenUtils.ScreenLeft + screenWidth / 2,
                ScreenUtils.ScreenTop + radius));

        // left side asteroid
        aestroid = Instantiate<GameObject>(prefabAestroid);
        script = aestroid.GetComponent<Aestroid>();
        script.Initialize(Direction.Right,
            new Vector2(ScreenUtils.ScreenLeft - radius,
                ScreenUtils.ScreenBottom + screenHeight / 2));

        // bottom side asteroid
        aestroid = Instantiate<GameObject>(prefabAestroid);
        script = aestroid.GetComponent<Aestroid>();
        script.Initialize(Direction.Up,
            new Vector2(ScreenUtils.ScreenLeft + screenWidth / 2,
                ScreenUtils.ScreenBottom - radius));

    }
}
