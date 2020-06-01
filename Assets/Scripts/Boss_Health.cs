using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_Health : MonoBehaviour
{
    public Animator animator;
    public int health = 500;

    


    public bool unTouchble = false;
    
    public void GiveDamage(int damage)
    {
        if (unTouchble == true)
        {
            return;
        }

        health -= damage;

        if (health < 1)
        {
            unTouchble = true;
            animator.SetTrigger("Dead");   
        }
        else if (health < 150)
        {
            
            animator.SetBool("Enrage", true);

        }

    }

    public void Die()
    {
        animator.ResetTrigger("Dead");
        Destroy(gameObject);
        gameObject.SetActive(false);
        MainMenu();
        
    }

    void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
