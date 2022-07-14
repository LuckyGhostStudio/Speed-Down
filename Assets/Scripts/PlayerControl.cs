using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Animator animator;

    public float speed;
    float xVelocity;

    public GameObject platformCheck;    //检测点
    public float checkRadiu;            //检测半径
    public LayerMask platform;          //检测层
    public bool isOnGround;

    bool playerDeath;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        isOnGround = Physics2D.OverlapCircle(platformCheck.transform.position, checkRadiu, platform);

        animator.SetBool("isOnGround", isOnGround);

        Movement();
    }

    void Movement()
    {
        xVelocity = Input.GetAxisRaw("Horizontal");

        rigidbody2d.velocity = new Vector2(xVelocity * speed, rigidbody2d.velocity.y);

        animator.SetFloat("speed", Mathf.Abs(rigidbody2d.velocity.x));

        if (xVelocity != 0) transform.localScale = new Vector3(xVelocity, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fan"))
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, 10f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spike"))
        {
            animator.SetTrigger("death");
        }
    }

    public void PlayerDeath()
    {
        playerDeath = true;
        GameManager.GameOver(playerDeath);
    }

    private void OnDrawGizmosSelected()       //画出检测范围
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(platformCheck.transform.position, checkRadiu);
    }
}
