using UnityEngine;

public class Hands_collisions : MonoBehaviour
{
    public bool hands_collided = false;
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Obstacle"))
        {
            hands_collided = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Obstacle"))
        {
            hands_collided = false;
        }
    }
}
