using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public GameObject player;
    public PlayerMove playerMovement;

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + player.transform.localScale.y / 2.7f, -350f);
    }
}
