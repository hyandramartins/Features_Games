using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Animator animator;

    private Rigidbody2D rigidbody2DPlayer;
    private Vector2 input;
    private bool isKnockback;

    void Start()
    {
        rigidbody2DPlayer = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(!isKnockback)
        {
            rigidbody2DPlayer.linearVelocity = input * speed;
            animator.SetBool("isWalking", rigidbody2DPlayer.linearVelocity.magnitude > 0);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();

        if(input.x != 0)
        {
            animator.SetFloat("InputX", input.x);
            animator.SetFloat("LastInputX", input.x);
        }
    }

    public void Knockback(Transform dealDamage, float knockbackForce, float knockbackDuration)
    {
        StartCoroutine(TimeForKnockback(dealDamage, knockbackForce, knockbackDuration));
    }

    IEnumerator TimeForKnockback(Transform dealDamage, float knockbackForce, float knockbackDuration)
    {
        isKnockback = true;

        Vector2 direction = (transform.position - dealDamage.position);
        rigidbody2DPlayer.linearVelocity = direction * knockbackForce;

        yield return new WaitForSeconds(knockbackDuration);

        rigidbody2DPlayer.linearVelocity = Vector2.zero;
        isKnockback = false;
    }
}