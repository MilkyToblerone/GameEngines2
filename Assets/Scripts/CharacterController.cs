using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField] InputActionReference moveRef;
    [SerializeField] InputActionReference sprintRef;
    [SerializeField] float turnSmoothTime = 0.1f;
    Rigidbody rb;
    float turnSmoothVelocity;
    Vector2 currentMovement;
    Animator animator;
    bool isRunning;
    [SerializeField] float walkSpeed;
    [SerializeField] float sprintSpeed;
    float moveSpeed;
    void Awake()
    {
        sprintRef.action.performed += Run;
        sprintRef.action.canceled += RunCancel;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void RunCancel(InputAction.CallbackContext context)
    {
        isRunning = false;
    }

    private void Run(InputAction.CallbackContext context)
    {
        isRunning = true;
    }

    void Update()
    {
        currentMovement = moveRef.action.ReadValue<Vector2>();
    }
    void FixedUpdate()
    {
        print(moveSpeed);
        if (currentMovement == Vector2.zero)
        {
            moveSpeed = 0;
        }
        else
        {
            moveSpeed = isRunning ? sprintSpeed : walkSpeed;
        }
        animator.SetFloat("Speed", moveSpeed / 10);
        rb.linearVelocity = new Vector3(currentMovement.x, rb.linearVelocity.y, currentMovement.y) * moveSpeed;
        float targetAngle = MathF.Atan2(currentMovement.x, currentMovement.y) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }
    

    
}
