using UnityEngine;
using System.Collections;

public class EnemyPatrol : EnemyMoviment
{
    public Transform[] waypoints;
    public int currentWaypoint;
    public float waitTime;

    private bool isWaiting;

    public override void Move(Transform target)
    {
        base.Move(target);

        if (!chasing && !isWaiting)
        {
            Vector2 direction = (waypoints[currentWaypoint].position - transform.position).normalized;

            rigidbody2DEnemy.linearVelocity = direction * speed;
            FlipVerify(direction.x);
            SetWalking(true);
            SetIdle(false);

            if (Vector2.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
            {   
                StartCoroutine(WaitInWaypoint());
            }
        }
    }

    IEnumerator WaitInWaypoint()
    {
        isWaiting = true;

        SetWalking(false);
        SetIdle(true);

        yield return new WaitForSeconds(waitTime);

        currentWaypoint++;

        if (currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0;
        }

        isWaiting = false;
    }

}
