using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attacks : MonoBehaviour
{
    public Animator animator;
    public LayerMask playerLayer;

    public Transform waveAttackPoint;

    public float attackRange = 1.5f;


    public void WaveAttack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(waveAttackPoint.position, attackRange, playerLayer);
        //damage them'
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<HealtBar>().GiveDamage(1);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (waveAttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(waveAttackPoint.position, attackRange);
    }


}
