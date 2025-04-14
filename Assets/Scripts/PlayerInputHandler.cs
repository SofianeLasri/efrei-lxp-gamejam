using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("Contrôles")]
    private PlayerInput _playerInput;

    private InputAction _leftMove;
    private InputAction _rightMove;
    [SerializeField] private Vector2 leftMoveValue;
    [SerializeField] private Vector2 rightMoveValue;
    
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
    }
    
    public Vector2 GetLeftMoveValue()
    {
        return leftMoveValue;
    }
    
    public Vector2 GetRightMoveValue()
    {
        return rightMoveValue;
    }
}
