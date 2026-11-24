using UnityEngine;

public class EnemyPatrol : EnemyMoviment
{
    public Transform[] waypoints;
    public int currentWaypoint;
    public override void Move(Transform target)
    {
        base.Move(target);

        Vector2 direction = (waypoints[currentWaypoint].position - transform.position).normalized;
        rigidbody2DEnemy.linearVelocity = direction * speed;

        SetWalking(true);
        SetIdle(false);
        FlipVerify(direction.x);

        if(Vector2.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
        {
            currentWaypoint++;

            if(currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }
    }
}
