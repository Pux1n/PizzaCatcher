using UnityEngine;
using System.Collections;
public class playerMove : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed;
    Vector2 move;
    bool moveLeft;
    bool dontMove;
    bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dontMove = true;
    }

    void Update()
    {
        if (!ItemSpawn.gameOver && PauseActive.pause == 0)
        {
            KeybordMoving();
        }
    }

    void KeybordMoving()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        
        if (horizontal < 0)
        {
            rb.velocity = new Vector2(speed * horizontal, rb.velocity.y);
            if (facingRight)
            {
                Flip();
            }
        }
        else if (horizontal > 0)
        {
            rb.velocity = new Vector2(speed * horizontal, rb.velocity.y);
            if (!facingRight)
            {
                Flip();
            }
        }
        else
        {
            HandleMoving();
        }
    }

    void HandleMoving()
    {
        if (dontMove)
        {
            StopMoving();
        }
        else
        {
            if (moveLeft)
            {
                MoveLeft();
                if (facingRight)
                {
                    Flip();
                }
            }
            else
            {
                MoveRight();
                if (!facingRight)
                {
                    Flip();
                }
            }
        }
    }

    public void AllowMovement(bool movement)
    {
        dontMove = false;
        moveLeft = movement;
    }

    public void DontAllowMovement()
    {
        dontMove = true;
    }

    public void MoveLeft()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }
    public void MoveRight()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    public void StopMoving()
    {
        rb.velocity = new Vector2(0f, rb.velocity.y);
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }
}