using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private Collider playerCollider;
    // private Animator animator;

    // Horizontal Movement
    public float walkSpeed = 3;
    public float sprintSpeed = 4;
    private float currentSpeed;
    private float horizontalInput;

    // Hanging
    private bool canMove = true;

    // Rotation
    private bool isRight = true;
        
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();
        // animator = GetComponent<Animator>();
        rb.freezeRotation = true;
    }

    void Update()
    {   
        // UpdateAnimations();

        if (canMove)
        {
            // Horizontal movement
            if (Keyboard.current.aKey.isPressed)
            {
                horizontalInput = -1f;
                isRight = false;
            }
            else if (Keyboard.current.dKey.isPressed)
            {
                horizontalInput = 1f;
                isRight = true;
            }
            else
            {
                horizontalInput = 0f;
            }

            // Rotation
            if (isRight)
            {
                transform.localEulerAngles = new Vector3(0f, 90f, 0f);
            }
            else
            {
                transform.localEulerAngles = new Vector3(0f, 270f, 0f);
            }
        }

        // Sprint
        if (Keyboard.current.shiftKey.isPressed)
        {
            currentSpeed = sprintSpeed;
        }
        else 
        {
            currentSpeed = walkSpeed;
        }
    }

    void FixedUpdate()
    {
        Vector3 velocity = rb.linearVelocity;
        
        if (canMove)
        {
            // Movement
            float targetMoveSpeed = horizontalInput * currentSpeed;
            
            // Move normally
            velocity.x = targetMoveSpeed;
            rb.linearVelocity = velocity;
        }
    }

    // private void UpdateAnimations()
    // {
    //     float animationSpeed = Mathf.Abs(horizontalInput) * currentSpeed;
    //     if (!canMove) animationSpeed = 0;
    //     animator.SetFloat("Speed", animationSpeed);
    // }
}