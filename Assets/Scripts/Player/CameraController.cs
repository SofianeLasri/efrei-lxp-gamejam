using UnityEngine;

namespace Player
{
    public class CameraController : MonoBehaviour
    {
        public Transform target;
        public Vector2 startPosition;
        public Vector2 endPosition;
        
        private float initialZPosition;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            initialZPosition = transform.position.z;
        }

        // Update is called once per frame
        void Update()
        {
            if (target == null)
                return;
                
            Vector2 targetPosition2D = new Vector2(target.position.x, target.position.y);
            
            Vector2 railVector = endPosition - startPosition;
            float railLength = railVector.magnitude;
            Vector2 railDirection = railVector / railLength;
            
            Vector2 targetRelativeToStart = targetPosition2D - startPosition;
            float dotProduct = Vector2.Dot(targetRelativeToStart, railDirection);
            
            float clampedDot = Mathf.Clamp(dotProduct, 0, railLength);
            
            Vector2 newPosition = startPosition + (railDirection * clampedDot);
            
            transform.position = new Vector3(newPosition.x, newPosition.y, initialZPosition);
        }
    }
}