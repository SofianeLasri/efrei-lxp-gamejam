using Player;
using UnityEngine;

public class Player_weigt_manager : MonoBehaviour
{
    public PlayerInputHandler inputHandler;  // Drag & drop le script ici dans l’inspecteur
    public Hands_collisions handsCollision1;     // Pareil ici
    public Hands_collisions handsCollision2;     // Pareil ici
    public Rigidbody2D Right_Hand;
    public Rigidbody2D Left_Hand;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inputHandler = GetComponentInParent<PlayerInputHandler>();
        
    }

    private void Update()
    {
        if (inputHandler == null || handsCollision1 == null || rb == null || handsCollision2 == null)
            return;

        bool grabbingLeft = inputHandler.IsGrabbingWithLeftHand();
        bool grabbingRight = inputHandler.IsGrabbingWithRightHand();
        bool handsCollided1 = handsCollision1.hands_collided;
        bool handsCollided2 = handsCollision2.hands_collided;

        if (grabbingLeft && handsCollided2)
        {
            rb.mass = 10f;
            Left_Hand.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            Left_Hand.constraints = RigidbodyConstraints2D.None;
        }

        if (grabbingRight && handsCollided1)
        {
            rb.mass = 10f;
            Right_Hand.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            Right_Hand.constraints = RigidbodyConstraints2D.None;
        }

        if (!(grabbingRight && handsCollided1) && !(grabbingLeft && handsCollided2))
        {
            rb.mass = 60f;
        }
    }
}
