using UnityEngine;
using UnityEngine.InputSystem;

public class Example : MonoBehaviour
{
    [Header("Contrôles")]
    private PlayerInput _playerInput;

    private InputAction _leftMove;
    private InputAction _rightMove;
    [SerializeField] public Vector2 _leftMoveValue;
    [SerializeField] public Vector2 _rightMoveValue;
    
    // Awake se lance avant Start
    void Awake()
    {
        // On récupère l'instance de PlayerInput (à ajouter à la main dans l'inspecteur)
        _playerInput = GetComponent<PlayerInput>();
        
        // On récupère les actions de mouvement gauche et droite
        _leftMove = _playerInput.currentActionMap.FindAction("LeftMove");
        
        // Maintenant on définie la valeur la variable _leftMoveValue
        _leftMove.performed += ctx => _leftMoveValue = ctx.ReadValue<Vector2>();
        _leftMove.canceled += ctx => _leftMoveValue = Vector2.zero;
        
        // On répète :)
        _rightMove = _playerInput.currentActionMap.FindAction("RightMove");
        _rightMove.performed += ctx => _rightMoveValue = ctx.ReadValue<Vector2>();
        _rightMove.canceled += ctx => _rightMoveValue = Vector2.zero;
    }

    void FixedUpdate()
    {
        
    }
}
