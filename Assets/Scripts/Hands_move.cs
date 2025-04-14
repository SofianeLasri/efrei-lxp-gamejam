using UnityEngine;

public class Hands_move : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(horizontal, vertical) * speed;
        rb.linearVelocity = move;
    }
    
}
