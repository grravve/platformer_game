using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public Animator animator; 

    public float moveInput;

    [SerializeField] private Rigidbody2D rb;

    private bool faceRight = true;

    public bool isGraunded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsvalue; 





    // Start is called before the first frame update
    private void Start()
    {
        extraJumps = extraJumpsvalue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        isGraunded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        
        if (faceRight == false && moveInput > 0)
        {
            Flip();
        }
        if (faceRight == true && moveInput < 0)
        {
            Flip();

        }
    }

    void Update()
    {
        if(isGraunded == true)
        {
            extraJumps = extraJumpsvalue;
        }

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);


        if( Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpHeight;
            extraJumps--;
        }

        else if ( Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGraunded == true)
        {
            rb.velocity = Vector2.up * jumpHeight;
        }
    }


    void Flip()
    {
        faceRight = !faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
