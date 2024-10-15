using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform playerTranform;
    [SerializeField] private float speed = 2;
    SpriteRenderer spriteRenderer;

    [SerializeField] private float chaseDistance = 3f;
    [SerializeField] private float AttackDistance = 1f;





    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Vector2.Distance(transform.position, playerTranform.position) <= chaseDistance)
        {
            chaseState();
        }

    }

    //StateMachine
    void idelState() { }
    void chaseState()
    {
        transform.position =
            Vector2.MoveTowards(
                transform.position,
                playerTranform.position,
                speed * Time.deltaTime
                );

        if (playerTranform.position.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
    void attackState() { }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackDistance);
    }
}