using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoPersonaje : MonoBehaviour
{
    private SpriteRenderer spritePersonaje;
    private Animator animator;
    public float velocidad = 10f;
    public float fuerzaSalto = 12f;
    public Transform chequeoSuelo;
    public float radioChequeo = 0.12f;
    public LayerMask capaSuelo;
    private bool enSuelo;
    private Vector2 moveInput;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spritePersonaje = GetComponent<SpriteRenderer>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && enSuelo)
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
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
        animator.SetBool("enSuelo", enSuelo);

        if (moveInput.x * velocidad < 0)
        {
            spritePersonaje.flipX = true;
        }
        else if (moveInput.x * velocidad > 0)
        {
            spritePersonaje.flipX = false;
        }

        enSuelo = Physics2D.OverlapCircle(chequeoSuelo.position, radioChequeo, capaSuelo);
    }
    
    private void OnDrawGizmosSelected()
    {
        if (chequeoSuelo == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(chequeoSuelo.position, radioChequeo);
    }
}
