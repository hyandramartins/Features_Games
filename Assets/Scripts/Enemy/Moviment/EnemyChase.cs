using UnityEngine;

public class EnemyChase : EnemyMoviment
{
    public override void Move(Transform target)
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rigidbody2DEnemy.linearVelocity = direction * speed;
        FlipVerify(direction.x);
        SetWalking(true);
        SetIdle(false);
    }
}
