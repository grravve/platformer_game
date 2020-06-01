using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private int health = 500;

    public bool unTouchble = false;
    public bool dead = false;

    public void GiveGamage(int damage)
    {
        if (unTouchble)
        {
            return;
        }

        if (health <= 0)
        {
            animator.SetTrigger("Dead");
            if(dead)
            {
                Destroy(gameObject);
            }
        }
        else if (health > 0)
        {
            


        }
    }
}
