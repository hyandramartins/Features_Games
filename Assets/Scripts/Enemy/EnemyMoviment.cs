using System;
using UnityEngine;

public class EnemyMoviment : MonoBehaviour
{   
    protected Rigidbody2D rigidbody2DEnemy;
    protected Animator animator;
    public float speed;

    public float minDistance;
    public float safeDistance;

    public bool chasing;

    private int facingDirection = 1;

    void Start()
    {
        rigidbody2DEnemy = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public virtual void Move(Transform target)
    {
        Vector2 direction = (target.position - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, target.position);

        if(!chasing && distance < minDistance)
        {
            chasing = true;
        }
        if(chasing && distance >= safeDistance)
        {
            chasing = false;
        }

        if(chasing)
        {
            FlipVerify(direction.x);
            rigidbody2DEnemy.linearVelocity = direction * speed;
            SetWalking(true);
            SetIdle(false);
        }
        else
        {
            FlipVerify(direction.x);
            rigidbody2DEnemy.linearVelocity = Vector2.zero;
            SetWalking(false);
            SetIdle(true);
        }
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
