using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HealtBar : MonoBehaviour
{

    [SerializeField] private int health;
    public int numberOfHealth;
    private Animator animator;

    public Image[] hearts;
    public Sprite fullHeart;

    private float deathTime = 1.11f;

    public bool unTouchble = false;
    

    [SerializeField] private float currentDeathTime;
 


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        currentDeathTime = 0;
        
    }

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (health > numberOfHealth)
            {
                health = numberOfHealth;
            }


            if (i < health)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if(currentDeathTime > 0f)
        {
            currentDeathTime -= Time.deltaTime;
            if(currentDeathTime <= 0f)
            {
                Time.timeScale = 0;
            }
        }

        

    }

    public void GiveDamage(int damage)
    {
        if(unTouchble)
        {
            return;
        }

        if (health > 0)
        {
            animator.SetTrigger("Hurted");
            StartCoroutine("Hurt");
            health -= damage;
            
        }
        else if (health == 0 && currentDeathTime == 0f)
        {
            animator.SetTrigger("Death");
            //currentDeathTime = deathTime;
            MainMenu();
        }
        

    }

    public void GiveHealth()
    {
        health+=2;
    }

    public int GetHealth()
    {
        return health;
    }

    IEnumerator Hurt()
    {
        yield return new WaitForSeconds(0.5f);
        animator.ResetTrigger("Hurted");
    }

    



void MainMenu()
{
    SceneManager.LoadScene("MainMenu");
}

}