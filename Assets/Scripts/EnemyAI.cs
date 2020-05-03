using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Animator animator;
    [SerializeField] public Transform player;
    public float attackRange = 3.5f;
    public float speed = -4;
    [SerializeField] private float distanceToPlayer;
    private Rigidbody2D rb;
    private float fakeX;
    [SerializeField] private Vector2 direction;
    private Vector2 headinToPlayer;
    bool faceRight = false;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector2.Distance(gameObject.transform.position, player.position);// дальность обнаружения для противника
        if (distanceToPlayer < attackRange) 
        {
            FollowPlayer();
        }
        else if (distanceToPlayer > attackRange) 
        {
            StopFollowPlayer();
        }
        
        
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(direction.x * speed, 0); // движение агента
    }

    private void FollowPlayer()
    {
        
        animator.SetBool("Find", true);

        if(player.transform.position.x < gameObject.transform.position.x && faceRight == true)
        {
            Flip();
        }
        if (player.transform.position.x > gameObject.transform.position.x && faceRight == false)
        {
            Flip();
        }
        headinToPlayer = gameObject.transform.position - player.transform.position;
        direction = headinToPlayer / distanceToPlayer;
        if (distanceToPlayer <= 1.5f)
        {
            StopFollowPlayer();
        }
        if(GetComponent<Enemy>().currentHealth <= 0)
        {
            StopFollowPlayer();
        }
    }

    private void StopFollowPlayer()
    {
        animator.SetBool("Find", false);
        direction.x = 0;
    }

    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 Scaler = gameObject.transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }


}
