using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Boss_Attacks : MonoBehaviour
{
    public Animator animator;
    public LayerMask playerLayer;

    public Transform waveAttackPoint;
    public Transform comboAttackPoint;


    public float attackRange = 1.5f;
    public float comboRange = 1.7f;



    public void WaveAttack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(waveAttackPoint.position, attackRange, playerLayer);
        //damage them'
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<HealtBar>().GiveDamage(1);
        }
    }

    public void ComboAttack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(comboAttackPoint.position, attackRange, playerLayer);
        //damage them'
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<HealtBar>().GiveDamage(1);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (waveAttackPoint != null)
        {
           Gizmos.DrawWireSphere(waveAttackPoint.position, attackRange);
        }
        else { return; }
        
        if(comboAttackPoint != null)
        {
            Gizmos.DrawWireSphere(comboAttackPoint.position, comboRange);

        }
        else { return; }
    }


}
