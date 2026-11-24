using System;
using UnityEngine;

public class EnemyMoviment : MonoBehaviour
{   
    protected Rigidbody2D rigidbody2DEnemy;
    protected Animator animator;
    public float speed;

    private int facingDirection = 1;

    void Start()
    {
        rigidbody2DEnemy = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public virtual void Move(Transform target)
    {
        
    }

    protected void SetWalking(bool walking)
    {
        animator.SetBool("isWalking", walking);
    }

    protected void SetIdle(bool idle)
    {
        animator.SetBool("isIdle", idle);
    }

    protected void FlipVerify(float direction)
    {
        if(direction > 0 && facingDirection < 0)
        {
            Flip();
        }
        else if(direction < 0 && facingDirection > 0)
        {
            Flip();
        }
    }
    private void Flip()
    {
        facingDirection *= -1;

        Vector2 scale = transform.localScale;

        scale.x = Math.Abs(scale.x) * facingDirection;
        transform.localScale = scale;
    }
}
