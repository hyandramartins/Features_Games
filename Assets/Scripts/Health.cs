using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;

    void Start()
    {
        health = maxHealth;
    }

    public void ReduceHealth(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
