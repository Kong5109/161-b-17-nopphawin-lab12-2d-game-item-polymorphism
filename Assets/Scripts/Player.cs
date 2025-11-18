using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;

    //move attibute
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 8;

    private Vector2 moveInput;

    private void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * speed, rb.linearVelocity.y);
    }

    private void Move()
    {
        // Movement (old input system)
        moveInput.x = Input.GetAxisRaw("Horizontal");
    }

    private void Jump()
    {
        // Jump (new input system)
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
