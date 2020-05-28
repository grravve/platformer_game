using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    public float attackRange = 3.5f;
    public float speed = -4;
    [SerializeField]private float distanceToPlayer;
    private Rigidbody2D rb;
    [SerializeField] private Vector2 direction;
    private Vector2 headinToPlayer;
    bool faceRight = false;
    public float viewDistance = 10f;



    [SerializeField] private float delay = 0.15f;
    private float chillTime;


    // Start is called before the first frame update
    void Start()
    {
        chillTime = 0f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(chillTime > 0f)
        {
            chillTime -= Time.deltaTime;
        }
        distanceToPlayer = Vector2.Distance(gameObject.transform.position, player.transform.position);// дальность обнаружения для противника
        if (distanceToPlayer <= viewDistance) 
        {
            FollowPlayer();
        }
        else if (distanceToPlayer > viewDistance) 
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
        if (distanceToPlayer <= attackRange)
        {
            StopFollowPlayer();            
            if(chillTime <= 0f)
            {
                animator.SetBool("killing", true);
                Attack();
            }            
        }
        else
        {
            animator.SetBool("killing", false);
        }
        
        if(GetComponent<Enemy>().currentHealth <= 0)
        { 
            gameObject.SetActive(false);
            HealtBar damage = player.GetComponent<HealtBar>();
            damage.GiveHealth();
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

    private void Attack()
    {
        chillTime = delay;
        HealtBar damage = player.GetComponent<HealtBar>();
        damage.GiveDamage(1);
        if(damage.GetHealth() == 0)
        {
            StopFollowPlayer();
            animator.SetBool("killing", false);
        }
    }

    
}
