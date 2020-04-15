using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float startTime = 5f;
    public bool exit = false;

    // Update is called once per frame
     void Start()
    {
        this.enabled = false;    
    }
    void Update()
    {
        if (startTime >= 0)
        {
            startTime -= Time.deltaTime;
        }
        else
        {
            exit = true;
        }
    }
}
