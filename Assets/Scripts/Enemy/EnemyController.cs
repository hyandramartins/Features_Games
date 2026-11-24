using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyMoviment enemyMoviment;
    public Transform player;

    private void FixedUpdate()
    {
        enemyMoviment.Move(player); 
    }
}
