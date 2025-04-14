using UnityEngine;

public class Hands_move : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb_right;
    public Rigidbody2D rb_left;

    private Example script_xy;
    void Start()
    {
        script_xy = GetComponent<Example>();
    }
    
    void FixedUpdate()
    {
        float horizontal_left = script_xy._leftMoveValue.x;
        float vertical_left = script_xy._leftMoveValue.y;
        float horizontal_right = script_xy._rightMoveValue.x;
        float vertical_right = script_xy._rightMoveValue.y;
        
        Vector2 move_right = new Vector2(horizontal_right, vertical_right) * speed;
        Vector2 move_left = new Vector2(horizontal_left, vertical_left) * speed;
        rb_right.linearVelocity = move_right;
        rb_left.linearVelocity = move_left;
    }
    
}
