using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class HandsMove : MonoBehaviour
    {
        public float speed = 5f;
        public Rigidbody2D rbRight;
        public Rigidbody2D rbLeft;
        private PlayerInputHandler _scriptXY;
        void Start()
        {
            _scriptXY = GetComponent<PlayerInputHandler>();
        }
    
        void FixedUpdate()
        {
            var leftMoveValue = _scriptXY.GetLeftMoveValue();
            var rightMoveValue = _scriptXY.GetRightMoveValue();
        
            float horizontalLeft = leftMoveValue.x;
            float verticalLeft = leftMoveValue.y;
            float horizontalRight = rightMoveValue.x;
            float verticalRight = rightMoveValue.y;
        
            Vector2 moveRight = new Vector2(horizontalRight, verticalRight) * speed;
            Vector2 moveLeft = new Vector2(horizontalLeft, verticalLeft) * speed;
            rbRight.linearVelocity = moveRight;
            rbLeft.linearVelocity = moveLeft;
        }
    
    }
}
