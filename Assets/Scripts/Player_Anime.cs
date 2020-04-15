using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Anime : MonoBehaviour
{
    public Animator animator;
    [SerializeField]
    private PlayerMove pl;


    public void Start()
    {
        pl = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    public void Update()
    {
        //RUN
        if (pl.moveInput > 0)
        {
            animator.SetBool("isRun", true);
        }

        else if (pl.moveInput < 0)
        {
            animator.SetBool("isRun", true);
        }

        else
        {
            animator.SetBool("isRun", false);
        }



        //JUMP
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetTrigger("Jump");
        }
    }
}
