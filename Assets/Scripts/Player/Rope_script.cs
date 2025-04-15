using UnityEngine;

namespace Player
{
    public class ImprovedRopePhysics : MonoBehaviour
    {
        public Transform startObject;
        public Transform endObject;
        public int segmentCount = 10;
        public float ropeThickness = 0.1f;
        public float segmentMass = 0.1f;
        public float jointStiffness = 10f;
        public float jointDamping = 0.7f;
        public LayerMask ropeLayer;
    
        [Header("Segment Length Settings")]
        public bool useCustomSegmentLength = false;
        public float customSegmentLength = 0.5f; // Default length in Unity units
    
        private GameObject[] segments;
        private LineRenderer lineRenderer;

        void Start()
        {
            CreateRope();
        }
    
        void Update()
        {
            if (lineRenderer != null && segments != null)
            {
                lineRenderer.SetPosition(0, startObject.position);
            
                for (int i = 0; i < segments.Length; i++)
                {
                    Debug.Log( "Segment " + i + " position: " + segments[i].transform.position);
                    lineRenderer.SetPosition(i + 1, segments[i].transform.position);
                }
            
                lineRenderer.SetPosition(segments.Length + 1, endObject.position);
            }
        }

        void CreateRope()
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.startWidth = ropeThickness;
            lineRenderer.endWidth = ropeThickness;
            lineRenderer.positionCount = segmentCount + 2;
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        
            segments = new GameObject[segmentCount];
        
            Vector3 direction = endObject.position - startObject.position;
            float distance = direction.magnitude;
        
            // Determine segment length - either custom or calculated based on distance
            float segmentLength;
            if (useCustomSegmentLength)
            {
                segmentLength = customSegmentLength;
            }
            else
            {
                segmentLength = distance / (segmentCount + 1);
            }
        
            int ropeLayerIndex = LayerMask.NameToLayer("Rope");
            if (ropeLayerIndex == -1)
            {
                ropeLayerIndex = 0;
            }
        
            for (int i = 0; i < segmentCount; i++)
            {
                // Position calculation changes if using custom length
                Vector3 segmentPosition;
                if (useCustomSegmentLength)
                {
                    // When using custom length, position segments along direction vector
                    segmentPosition = startObject.position + (direction.normalized * segmentLength * (i + 1));
                }
                else
                {
                    // Original equidistant spacing
                    segmentPosition = startObject.position + (direction.normalized * segmentLength * (i + 1));
                }
            
                segments[i] = new GameObject("Segment_" + i);
                segments[i].transform.position = segmentPosition;
                segments[i].transform.parent = transform;
                segments[i].layer = ropeLayerIndex;
            
                CircleCollider2D collider = segments[i].AddComponent<CircleCollider2D>();
                collider.radius = ropeThickness / 2f;
            
                Rigidbody2D rb = segments[i].AddComponent<Rigidbody2D>();
                rb.mass = segmentMass;
                rb.linearDamping = 0.5f;
                rb.angularDamping = 0.5f;
                //rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
            
                if (i == 0)
                {
                    ConnectSegments(segments[i], startObject.gameObject, segmentLength);
                }
                else
                {
                    ConnectSegments(segments[i], segments[i-1], segmentLength);
                }
            }
        
            ConnectSegments(endObject.gameObject, segments[segmentCount - 1], segmentLength);
        }
    
        void ConnectSegments(GameObject obj1, GameObject obj2, float distance)
        {
            DistanceJoint2D joint = obj1.AddComponent<DistanceJoint2D>();
            var obj2Rb = obj2.GetComponent<Rigidbody2D>();
            
            if(obj2Rb == null)
            {
                obj2Rb = obj2.GetComponentInParent<Rigidbody2D>();
            }
            
            joint.connectedBody = obj2Rb;
            joint.distance = distance * 0.95f;
            joint.enableCollision = false;
            joint.maxDistanceOnly = false;
        
            /*
        SpringJoint2D joint = obj1.AddComponent<SpringJoint2D>();
        joint.connectedBody = obj2.GetComponent<Rigidbody2D>();
        joint.distance = distance;
        joint.frequency = jointStiffness;
        joint.dampingRatio = jointDamping;
        joint.enableCollision = false;
        */
        }
    }
}
