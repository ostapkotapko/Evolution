using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 5f;

    public GameObject weapon;
    public bool canHit = true;
    public Animator animator;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isGrounded = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        animator.SetTrigger("Attack");
        if (weapon.GetComponent<WeaponCollision>().weaponOnEnemy == true && canHit == true)
        {
            weapon.GetComponent<WeaponCollision>().currEnemy.GetComponent<EnemyLogic>().enemyHp--;
        }
        canHit = false;
        Invoke(nameof(ResetHit), 0.5f);
    }

    void FixedUpdate()
    {
        if(moveInput.x > 0)
        {
            weapon.GetComponent<SpriteRenderer>().flipX = true;
            weapon.transform.localPosition = new Vector2(1, -0.25f);
        }
        else if (moveInput.x < 0)
        {
            weapon.GetComponent<SpriteRenderer>().flipX = false;
            weapon.transform.localPosition = new Vector2(-1, -0.25f);
        }
        rb.linearVelocity = new Vector2(moveInput.x * speed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void ResetHit()
    {
        canHit = true;
    }
}
