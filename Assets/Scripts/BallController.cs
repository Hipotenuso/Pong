using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;

public class BallController : MonoBehaviour
{
    public GameManager gameManager;
    private Rigidbody2D rb;
    public float SpeedUp = 1.1f;
    public Vector2 startingVelocity = new Vector2(5f, 5f);

    public void ResetBall()
    {
        transform.position = Vector3.zero;

        if (rb == null) rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = startingVelocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 newVelocity = rb.linearVelocity;
            newVelocity.y = -newVelocity.y;
            rb.linearVelocity = newVelocity;
        }
        
        if (collision.gameObject.CompareTag("Jogador"))
        {
            rb.linearVelocity = new Vector2(-rb.linearVelocity.x, rb.linearVelocity.y);
            rb.linearVelocity *= SpeedUp;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            rb.linearVelocity = new Vector2(-rb.linearVelocity.x, rb.linearVelocity.y);
            rb.linearVelocity *= SpeedUp;
        }
        if (collision.gameObject.CompareTag("WallEnemy"))
        {
            gameManager.ScoreJogador();
            ResetBall();
        }
        else if (collision.gameObject.CompareTag("WallJogador"))
        {
            gameManager.ScoreEnemy();
            ResetBall();
        }
    }
}