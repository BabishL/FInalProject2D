using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    public float speed;
    public float jump;
    private Animator anim;

    public Vector2 boxsize;
    public float castDistance;
    public LayerMask groundLayer;

    //for knockback
    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KnockFromRight;

    public bool flippedLeft;
    public bool facingRight;
    void Start()
    {
     body = GetComponent<Rigidbody2D>();  
     spriteRenderer = GetComponent<SpriteRenderer>();
     anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");

        if (KBCounter <= 0)
        {
            body.velocity = new Vector2(horizontalMovement * speed, body.velocity.y);
        }
        else
        {
            if (KnockFromRight == true)
            {
                body.velocity = new Vector2(-KBForce, KBForce);
            }
            if(KnockFromRight == false)  
            {
                body.velocity = new Vector2(KBForce, KBForce);
            } 

            KBCounter -= Time.deltaTime;
        }



        if (horizontalMovement <0)
        {
            facingRight = false;
            Flip(false);
        }
        else 
        {
            facingRight = true;
            Flip(true);
        }

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            body.AddForce(new Vector2(body.velocity.x, jump*10));
        }

        anim.SetBool("Run", horizontalMovement != 0);
    }

    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxsize,0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxsize);
    }

    void Flip (bool facingRight)
    {
        if(flippedLeft && facingRight)
        {
            transform.Rotate(0, -180, 0);
            flippedLeft = false;
        }
        if(!flippedLeft && !facingRight)
        {
            transform.Rotate(0, -180, 0);
            flippedLeft=true;
        }
    }
}
