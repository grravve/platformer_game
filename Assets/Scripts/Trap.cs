using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.GetComponent<HealtBar>())
        {
            HealtBar damage = other.GetComponent<HealtBar>();
            damage.GiveDamage(2);
            
        }
    }
}
