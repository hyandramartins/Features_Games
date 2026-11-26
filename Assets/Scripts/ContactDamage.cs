using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    public int damage;

    public float knockbackForce;
    public float knockbackDuration;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();
        if(health != null)
        {
            health.ReduceHealth(damage);
        }

        PlayerController playerController = collision.GetComponent<PlayerController>();
        if(playerController != null)
        {
            playerController.Knockback(transform, knockbackForce, knockbackDuration);
        }
    }
}
