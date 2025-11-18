using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [field : SerializeField] public int Coin {  get; set; } = 0;
    [field: SerializeField] public int Health { get; set; } = 50;
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();
        if (item != null)
        {
            item.PickUp(this);
        }
    }

    public void AddCoin(int value)
    {
        Coin += value;
        Debug.Log($"Pick Up Coin! Total coin: " +Coin);
    }

    public void Heal(int value)
    {
        Health += value;
        Debug.Log($"Pick Up Heal! Current Health: " + Health);
    }

    public void Move()
    {
        // Movement (old input system)
        moveInput.x = Input.GetAxisRaw("Horizontal");
    }

    public void Jump()
    {
        // Jump (new input system)
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
