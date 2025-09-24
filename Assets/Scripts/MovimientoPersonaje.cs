using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoPersonaje : MonoBehaviour
{
    private SpriteRenderer spritePersonaje;
    private Animator animator;
    public float velocidad = 10f;
    private Vector2 moveInput;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spritePersonaje = GetComponent<SpriteRenderer>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        moveInput = new Vector2(input.x, 0f);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * velocidad, rb.linearVelocity.y);
        animator.SetFloat("camina", Mathf.Abs(moveInput.x * velocidad));

        if (moveInput.x * velocidad < 0)
        {
            spritePersonaje.flipX = true;
        }
        else if (moveInput.x * velocidad > 0)
        {
            spritePersonaje.flipX = false;
        }
    }
}
