using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    public float speed;
    private Animator anim;
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

        body.velocity = new Vector2( horizontalMovement * speed, body.velocity.y);

        if (horizontalMovement < 0)
        {
            spriteRenderer.flipX = true;
        }
        else 
        {
            spriteRenderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }

        anim.SetBool("Run", horizontalMovement != 0);
    }
}
