using UnityEngine;

public class Jump : MonoBehaviour
{
    bool isGrounded = false;
    public float jumpHeight = 15.0f;
    public Rigidbody2D rb;
    float defaultGravity;
    float fallMultiplier = 3.0f;
    float lowFallMultiplier = 2.0f;
    public float minimumJumpVelocity = 10.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaultGravity = GetComponent<Rigidbody2D>().gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }

        // if the character is falling, move faster.
        if (rb.linearVelocityY < 0f)
        {
            rb.gravityScale = fallMultiplier;
        }
        else if (rb.linearVelocityY > 0f && rb.linearVelocityY < minimumJumpVelocity && !Input.GetButton("Jump"))
        {
            rb.linearVelocityY = 0;
            rb.gravityScale = lowFallMultiplier;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            rb.gravityScale = defaultGravity;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
