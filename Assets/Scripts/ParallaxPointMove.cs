using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxPointMove : MonoBehaviour
{
    public GameObject cam;
    public Transform spawnPoint;

    void Start()
    {
        gameObject.transform.position = cam.transform.position;
    }

    void FixedUpdate()
    {
        gameObject.transform.position = new Vector2(cam.transform.position.x, 0f);       
    }
}
