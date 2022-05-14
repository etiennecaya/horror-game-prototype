using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _input;
    private CharacterController _characterController;
    private Vector3 _rawInputMovement;
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _runningspeed = 1f;
    [SerializeField] private float _rotationSpeed = 1f;
    [SerializeField] private bool _characterRotates = false;
    public bool FlashLightOn = false;
    private bool _running = false;

    private void Awake() 
    {
        _input = new PlayerInput();
        _characterController = GetComponent<CharacterController>();

        _input.PlayerControls.Movement.started += OnMovement;
        _input.PlayerControls.Movement.performed += OnMovement;
        _input.PlayerControls.Movement.canceled += OnMovement;

    }

    private void Update() 
    {
        if (_characterRotates)
        {
            HandleRotation(); 
        }
        HandleMovement();
    }

    private void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 inputMovement = context.ReadValue<Vector2>();
        _rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
        _rawInputMovement.Normalize();
    }

    private void OnToggleFlashLight(InputAction.CallbackContext context)
    {
       FlashLightOn = context.control.IsPressed();
    }

    private void OnRun(InputAction.CallbackContext context)
    {
        _running = context.ReadValueAsButton();
    }

    private void  HandleMovement()
    {
        if(_running)
        {
            _characterController.Move(transform.TransformDirection(_rawInputMovement) * _runningspeed * Time.deltaTime);
        }
        else
        {
            _characterController.Move(transform.TransformDirection(_rawInputMovement) * _moveSpeed * Time.deltaTime);
        }
    }

    private void HandleRotation()
    {
        _characterController.transform.Rotate(Vector3.up * _rawInputMovement.x *_rotationSpeed * Time.deltaTime);
    }

    private void OnEnable() 
    {
        _input.PlayerControls.Enable();
    }
    private void OnDisable() 
    {
        _input.PlayerControls.Disable();
    }

    // IN CASE WE NEED TO SWTICH ACTION MAPS
    /*
    public void EnableGameplayControls()
    {
        playerInput.SwitchCurrentActionMap(actionMapPlayerControls);  
    }

    public void EnablePauseMenuControls()
    {
        playerInput.SwitchCurrentActionMap(actionMapMenuControls);
    }*/
}
