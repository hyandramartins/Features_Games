using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Animator animator;

    private Rigidbody2D rigidbody2DPlayer;
    private Vector2 input;

    void Start()
    {
        rigidbody2DPlayer = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigidbody2DPlayer.linearVelocity = input * speed;
        animator.SetBool("isWalking", rigidbody2DPlayer.linearVelocity.magnitude > 0);
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
}