using Unity.VisualScripting;
using UnityEngine;

public class EnemyKeepDistance : EnemyMoviment
{
    public float fleeDistance = 4f;
    public float safeDistance = 6f;
    public float fleeSpeedMultiplier = 1.5f;

    private bool retreating;

    public override void Move(Transform target)
    {
        Vector2 directionToPlayer = target.position - transform.position;
        float distance = Vector2.Distance(transform.position, target.position);

        //FlipVerify(directionToPlayer.x);

        if(!retreating && distance < fleeDistance)
        {
            retreating = true;
        }
        if(retreating && distance >= safeDistance)
        {
            retreating = false;
        }

        if(retreating)
        {
            FlipVerify(-directionToPlayer.x);
            Vector2 fleeDirection = -directionToPlayer.normalized;
            rigidbody2DEnemy.linearVelocity = fleeDirection * (speed * fleeSpeedMultiplier);
            SetWalking(true);
            SetIdle(false);
        }
        else
        {   
            FlipVerify(directionToPlayer.x);
            rigidbody2DEnemy.linearVelocity = Vector2.zero;
            SetWalking(false);
            SetIdle(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!retreating)
            return;
        if(collision.gameObject.CompareTag("Wall"))
        {
            retreating = false;
            rigidbody2DEnemy.linearVelocity = Vector2.zero;
            Debug.Log("Wall");
            SetWalking(false);
            SetIdle(true);
        }
    }
}
