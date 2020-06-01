using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    public BoxCollider2D wallLeft;
    public BoxCollider2D wallRight;

    public Transform player;
    public Transform boss;

    float fightRange = 8f;

    bool bossFight = false;

    void Update()
    {
        if(Vector2.Distance(player.position, boss.position) < fightRange && !bossFight)
        {
            bossFight = true;
            wallLeft.isTrigger = false;
            wallRight.isTrigger = false;
        }
    }


}
