using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxPointMove : MonoBehaviour
{
    public GameObject cam;


    void FixedUpdate()
    {
        gameObject.transform.position = new Vector2(cam.transform.position.x, 0f);       
    }
}
