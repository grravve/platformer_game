using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_LookControll : MonoBehaviour
{
    private bool isFlipped = false;

    public Transform player;

    

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > player.position.x && isFlipped)
        {
            isFlipped = false;
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
        }
        else if(transform.position.x < player.position.x && !isFlipped)
        {
            isFlipped = true;
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
        }
    }
}
