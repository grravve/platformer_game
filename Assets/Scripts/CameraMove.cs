using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform player;
    public PlayerMove playerMovement;
   
    private float cameraDistance = 90.0f;
    public float smoothTime = .15f;
    Vector3 velocity = Vector3.zero;

    public float yMaxValue = 0;
    public bool yMaxEnable = false;

    public float yMinValue = 0;
    public bool yMinEnable = false;


    void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }
    
    void FixedUpdate()
    {
        Vector3 playerPos = player.position;

        if(yMaxEnable && yMaxEnable)
        {
            playerPos.y = Mathf.Clamp(player.position.y, yMinValue, yMaxValue);
        }
        else if (yMaxEnable)
        {
            playerPos.y = Mathf.Clamp(player.position.y , player.position.y, yMaxValue);
        }
        else if(yMinEnable)
        {
            playerPos.y = Mathf.Clamp(player.position.y, yMinValue, player.position.y);
        }


        playerPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, playerPos, ref velocity, smoothTime);
        
        
    }
}
