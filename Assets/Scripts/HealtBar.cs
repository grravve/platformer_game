﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{

    [SerializeField] private int health;
    public int numberOfHealth;
    private Animator animator;

    public Image[] hearts;
    public Sprite fullHeart;

    private float deathTime = 1.11f;
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
                animator.ResetTrigger("Death");
                Time.timeScale = 0;
            }
        }
    }

    public void GiveDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
        }
        else if (health == 0 && currentDeathTime == 0f)
        {
            animator.SetTrigger("Death");
            currentDeathTime = deathTime;
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
}