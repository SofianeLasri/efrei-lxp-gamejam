using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [Header("Contrôles")]
        private PlayerInput _playerInput;

        private InputAction _leftMove;
        private InputAction _rightMove;
        private InputAction _leftGrab;
        private InputAction _rightGrab;
        [SerializeField] private Vector2 leftMoveValue;
        [SerializeField] private Vector2 rightMoveValue;
        [SerializeField] private bool isGrabbingWithLeftHand;
        [SerializeField] private bool isGrabbingWithRightHand;
    
        // Awake se lance avant Start
        void Awake()
        {
            // On récupère l'instance de PlayerInput (à ajouter à la main dans l'inspecteur)
            _playerInput = GetComponent<PlayerInput>();
        
            // On récupère les actions de mouvement gauche et droite
            _leftMove = _playerInput.currentActionMap.FindAction("LeftMove");
        
            // Maintenant on définie la valeur la variable _leftMoveValue
            _leftMove.performed += ctx => leftMoveValue = ctx.ReadValue<Vector2>();
            _leftMove.canceled += ctx => leftMoveValue = Vector2.zero;
        
            // On répète :)
            _rightMove = _playerInput.currentActionMap.FindAction("RightMove");
            _rightMove.performed += ctx => rightMoveValue = ctx.ReadValue<Vector2>();
            _rightMove.canceled += ctx => rightMoveValue = Vector2.zero;
            
            _leftGrab = _playerInput.currentActionMap.FindAction("LeftGrab");
            _leftGrab.performed += ctx => isGrabbingWithLeftHand = true;
            _leftGrab.canceled += ctx => isGrabbingWithLeftHand = false;
            
            _rightGrab = _playerInput.currentActionMap.FindAction("RightGrab");
            _rightGrab.performed += ctx => isGrabbingWithRightHand = true;
            _rightGrab.canceled += ctx => isGrabbingWithRightHand = false;
        }
    
        public Vector2 GetLeftMoveValue()
        {
            return leftMoveValue;
        }
    
        public Vector2 GetRightMoveValue()
        {
            return rightMoveValue;
        }
        
        public bool IsGrabbingWithLeftHand()
        {
            return isGrabbingWithLeftHand;
        }
        
        public bool IsGrabbingWithRightHand()
        {
            return isGrabbingWithRightHand;
        }
    }
}
