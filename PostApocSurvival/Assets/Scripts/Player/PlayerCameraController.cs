using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    PlayerLocomotion playerLocomotion;

    private float lookSpeedX = 2.0f;
    private float lookSpeedY = 2.0f;

    [SerializeField, Range(1, 10)] private float upperLookLimit = 80.0f;
    [SerializeField, Range(1, 10)] private float lowerLookLimit = 80.0f;


    private bool cursorOnScreen;
    private Camera playerCamera;
    private float rotationX;

    private void Awake()
    {
        playerCamera = Camera.main;
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void Start()
    {
        ToggleCursor(false);
        LoadSettings();
    }

    private void LoadSettings()
    {
        UserSettings settings = SettingsManager.instance.settings;

        lookSpeedX = settings.horizontalSensitivity;
        lookSpeedY = settings.verticalSensitivity;
    }
    public void ToggleCursor(bool show)
    {
        if (show)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        cursorOnScreen = Cursor.visible;
    }

    public void HandleCameraMovement(Vector2 cameraInput, float delta)
    {
        if (cursorOnScreen)
        {
            return;
        }
        rotationX -= cameraInput.y * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        //Rotate Player
        float r = cameraInput.x * lookSpeedX;
        playerLocomotion.HandleRotation(r);
    }
}
