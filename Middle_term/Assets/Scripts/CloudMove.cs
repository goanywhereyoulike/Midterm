using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    private bool dirRight = true;
    //public float speed = 1000.0f;
    void Update()
    {
        if (dirRight)
            transform.Translate(Vector2.right * 5 * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * 5 * Time.deltaTime);

        if (transform.position.x >= 150.0f)
        {
            dirRight = false;
        }

        if (transform.position.x <= -150.0f)
        {
            dirRight = true;
        }
    }
}
