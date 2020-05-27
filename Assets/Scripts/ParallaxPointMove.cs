using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxPointMove : MonoBehaviour
{
    public Camera cam;
    public GameObject player;
   
    void FixedUpdate()
    {
            gameObject.transform.position = new Vector2(cam.transform.position.x , 0f);
    }
}
