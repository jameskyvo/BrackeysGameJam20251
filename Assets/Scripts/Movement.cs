using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float horizontalInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        // Move the player
        transform.Translate(Vector2.right * horizontalInput * moveSpeed * Time.deltaTime);
    }
}
