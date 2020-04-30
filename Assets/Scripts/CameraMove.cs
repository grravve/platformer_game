using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public GameObject player;
    public PlayerMove playerMovement;
    public Transform spawnPoint;
    private float cameraDistance = 115.0f;


    void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }
    void Start()
    {
        transform.position = spawnPoint.transform.position;
    }
    void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + player.transform.localScale.y / 2.7f, -350f);
    }
}
