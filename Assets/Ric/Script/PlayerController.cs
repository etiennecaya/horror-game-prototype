using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private bool _activateInputsOnAwake;

    private PlayerInput _input;
    private CharacterController _characterController;

    private Vector3 _rawInputMovement;
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _rotationSpeed = 1f;
    [SerializeField] private float _groundedGravity = -0.5f;
    [SerializeField] private float _gravity = -9.8f;


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
        _input.PlayerControls.ToggleFlashLight.started += OnToggleFlashLight;
        if (_activateInputsOnAwake)
        {
            ActivateInputs();
        }

    }

    private void Update() 
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Defeated"))
        {
            return;
        }


        if (_characterRotates)
        {
            HandleRotation(); 
        }
        HandleMovement();
        HandleGravity();
    }

    private void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 inputMovement = context.ReadValue<Vector2>();
        _rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
        _rawInputMovement.Normalize();
    }

    private void OnToggleFlashLight(InputAction.CallbackContext context)
    {
        if (UIManager.Instance != null && UIManager.Instance._currentBattery <= 0)
        {
            return;
        }
        FlashLightOn = !FlashLightOn;
        {
            TurnFlashLightOn();
            UIManager.Instance.PlayFlashlightSound();
        }       
    }

    private void OnRun(InputAction.CallbackContext context)
    {
        _running = context.ReadValueAsButton();
    }

    private void  HandleMovement()
    {
        Vector3 nextMoveDirection = _rawInputMovement;
        if (_characterRotates)
        {
            nextMoveDirection = new Vector3(0, 0, _rawInputMovement.z);
            if(nextMoveDirection.z < 0)
            {
                _animator.SetBool("Forward", false);
            }
            else
            {
                _animator.SetBool("Forward", true);
            }
        }

        nextMoveDirection = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0) * nextMoveDirection;
        if (_rawInputMovement != new Vector3(0,_rawInputMovement.y,0))
        {
            _animator.SetBool("Walking", true);
            Vector3 lookAtDirection = transform.position + nextMoveDirection;
            lookAtDirection.y = transform.position.y;
            transform.LookAt(lookAtDirection);
        }
        else
        {
            _animator.SetBool("Walking", false);
        }


        _characterController.Move(nextMoveDirection * _moveSpeed * Time.deltaTime);
    }

    private void HandleRotation()
    {
        transform.Rotate(Vector3.up * _rawInputMovement.x *_rotationSpeed * Time.deltaTime);
    }

    private void HandleGravity()
    {
        if (_characterController.isGrounded)
        {
            _rawInputMovement.y = _groundedGravity;
        }
        else
        {
            _rawInputMovement.y += _gravity * Time.deltaTime;
        }
    }

    public void ActivateInputs()
    {
        _input.PlayerControls.Enable();
    }

    private void OnDisable() 
    {
        _input.PlayerControls.Disable();
    }

    private void TurnFlashLightOn()
    {
        if (FlashLightOn)
        {
            GameManager.Instance.LightCone.SetActive(true);
            if(UIManager.Instance != null)
            {
                UIManager.Instance.FlashLightIconOff.enabled = false;
                UIManager.Instance.FlashLightIconOn.enabled = true;
            }
        }
        else
        {
            GameManager.Instance.LightCone.SetActive(false);
            if(UIManager.Instance != null)
            {
                UIManager.Instance.FlashLightIconOff.enabled = true;
                UIManager.Instance.FlashLightIconOn.enabled = false;
            }
        }
    }

    public void OutOfBattery()
    {
        GameManager.Instance.LightCone.SetActive(false);
        if (UIManager.Instance != null)
        {
            UIManager.Instance.FlashLightIconOff.enabled = true;
            UIManager.Instance.FlashLightIconOn.enabled = false;
            FlashLightOn = false;
        }
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
