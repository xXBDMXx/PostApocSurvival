using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    PlayerControls playerControls;
    PlayerLocomotion playerLocomotion;
    PlayerCameraController playerCameraController;

    [SerializeField] Vector2 moveInput;
    [SerializeField] Vector2 cameraInput;
    [SerializeField] bool jumpInput;
    [SerializeField] bool crouchInput;
    [SerializeField] bool sprintInput;

    private void OnEnable()
    {
        if(playerControls == null)
        {
            playerControls = new PlayerControls();
        }

        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Awake()
    {
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerCameraController = FindObjectOfType<PlayerCameraController>(); //May cause issues when setting up networking
    }
    public void TickInput(float delta)
    {
        HandleMoveInputThisFrame(delta);
        HandleCameraInputThisFrame(delta);
        CheckIfShowCursorWasPressedThisFrame();

        if (CheckIfJumpInputIsPressed()) { jumpInput = true; } else { jumpInput = false; }
        if (CheckIfCrouchInputIsPressed()) { crouchInput = true; } else { crouchInput = false; }
        if (CheckIfSprintInputIsPressed()) { sprintInput = true; } else { sprintInput = false; }

        playerLocomotion.HandleSprinting(sprintInput);
    }

    private void HandleMoveInputThisFrame(float delta)
    {
        moveInput = playerControls.PlayerMovement.Move.ReadValue<Vector2>();
        playerLocomotion.HandleMovement(moveInput, delta);
    }

    private void HandleCameraInputThisFrame(float delta)
    {
        cameraInput = playerControls.PlayerCamera.MouseLook.ReadValue<Vector2>();
        playerCameraController.HandleCameraMovement(cameraInput, delta);
    }
    private bool CheckIfJumpInputIsPressed()
    {
        if (playerControls.PlayerMovement.Jump.IsPressed())
        {
            return true;
        }
        else return false;
    }
    private bool CheckIfCrouchInputIsPressed()
    {
        if (playerControls.PlayerMovement.Crouch.IsPressed())
        {
            return true;
        }
        else return false;
    }
    private bool CheckIfSprintInputIsPressed()
    {
        if (playerControls.PlayerMovement.Sprint.IsPressed()) {
            return true;
        }
        else return false;
    }

    private void CheckIfShowCursorWasPressedThisFrame()
    {
        if (playerControls.PlayerCamera.ToggleCursor.WasPressedThisFrame())
        {
            playerCameraController.ToggleCursor(!Cursor.visible);
        }
    }
}
