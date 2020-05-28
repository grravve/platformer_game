using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Chest : MonoBehaviour
{
    public Animator animator;
    public GameObject player;

    private bool exit = false;
  

   

    void OnTriggerStay2D(Collider2D other)
    {
        while (exit != true)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                animator.SetTrigger("PlayerOpen");
                print("opened");
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                animator.SetTrigger("PlayerClose");
                print("closed");
            }
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        exit = true;
    }

    




}
