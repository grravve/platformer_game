using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    bool noDamage = false;
    [SerializeField]  Timer timer;



    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Timer>();

        currentHealth = maxHealth;
    }

     void Update()
    {
        if (timer.exit == true)
        {
            Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // damage animation
        if(noDamage == false)
            animator.SetTrigger("Hurt");


        if (currentHealth <= 0)
        {
            timer.enabled = true;
            noDamage = true;
            Die();
        }

    }

    void Die()
    {
        
        animator.SetBool("isDead", true);
        
    }
}
