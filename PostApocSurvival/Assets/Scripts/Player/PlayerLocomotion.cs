using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    private Transform cameraTransform;

    private CharacterController characterController;

    [SerializeField] float moveSpeed;
    [SerializeField] float sprintModifier;

    public bool isSprinting;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
        characterController = GetComponent<CharacterController>();
    }
    public void HandleMovement(Vector2 moveInput, float delta)
    {
        Vector3 moveDir = cameraTransform.forward;
        moveDir.y = 0;
        moveDir = moveDir.normalized * moveInput.y;
        moveDir += cameraTransform.right * moveInput.x;
        moveDir.Normalize();
        moveDir.y = 0;

        float speed = moveSpeed;
        //Check if is Sprinting
        if (isSprinting && moveInput.y > 0)
        {
            speed = moveSpeed * sprintModifier;
        }

        characterController.SimpleMove(moveDir * delta * speed);
        
    }

    public void HandleSprinting(bool sprintInput)
    {
        isSprinting = sprintInput;
    }

    public void HandleRotation(float lookX)
    {
        transform.rotation *= Quaternion.Euler(0, lookX, 0);
    }
}
