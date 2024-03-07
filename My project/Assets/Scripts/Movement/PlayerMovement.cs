using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float origMoveSpeed;
    public float currentSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Crouching")]
    public float crouchYScale;
    public float beginYScale;
    private bool isCrouched;
    float distanceToSlide;
    float timeToReachSlide;


    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode crouchKey = KeyCode.LeftControl;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Slope Movement")]
    public float maxSloapAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    // Wall Run variables
    public LayerMask whatIsWall;
    public float wallrunForce, maxWallSpeed;
    bool isWallRight, isWallLeft;
    bool isWallRunning;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;

        beginYScale = transform.localScale.y;
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        // Wall Run
        CheckForWall();
        WallRunInput();

        // Added wall jump functionality
        if (Input.GetKey(jumpKey) && isWallRunning)
        {

            // Push off from the wall run
            rb.useGravity = true;
            Vector3 wallRunDirection = isWallRight ? -orientation.right : orientation.right;
            rb.velocity = wallRunDirection * jumpForce * .9f; // Adjust the force as needed
            StopWallRun();

        }
    }

    private void FixedUpdate()
    {
        MovePlayer();

    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
        if (Input.GetKeyDown(crouchKey))
        {
            isCrouched = true;
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);


            rb.AddForce(Vector3.forward * 5f, ForceMode.Impulse);
            moveDirection = Vector3.zero;
            Vector3 currentPos = transform.position;
            Vector3 slidePos = currentPos + orientation.forward * 8f;
            //rb.MovePosition(slidePos);

            distanceToSlide = Vector3.Distance(currentPos, slidePos);
            timeToReachSlide = distanceToSlide / 30f;

            StartCoroutine(Sliding(slidePos, timeToReachSlide));
        }
        else if (Input.GetKeyUp(crouchKey))
        {
            isCrouched = false;
            currentSpeed = origMoveSpeed;
            transform.localScale = new Vector3(transform.localScale.x, beginYScale, transform.localScale.z);

        }
    }

    IEnumerator Sliding(Vector3 targetPos, float time){

        float timeElapsed = 0f;
        Vector3 startPos = transform.position;

        while (timeElapsed < time)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, timeElapsed / time);
            timeElapsed += Time.deltaTime;
            yield return null;

        }
        transform.position = targetPos;
    }


    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
        
        {
            currentSpeed = origMoveSpeed;
        

        moveSpeed = currentSpeed;

        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
        if(isCrouched) 
        { 
         moveSpeed = 0f;
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private void WallRunInput()
    {
        if (Input.GetKey(KeyCode.D) && isWallRight) StartWallrun();
        if (Input.GetKey(KeyCode.A) && isWallLeft) StartWallrun();
    }

    private void StartWallrun()
    {
        rb.useGravity = false;
        isWallRunning = true;

        if (rb.velocity.magnitude <= maxWallSpeed)
        {
            rb.AddForce(orientation.forward * wallrunForce * Time.deltaTime);

            if (isWallRight)
                rb.AddForce(orientation.right * wallrunForce / 5 * Time.deltaTime);
            else
                rb.AddForce(-orientation.right * wallrunForce / 5 * Time.deltaTime);

            // Apply a slight downward force on the y-axis
            rb.AddForce(Vector3.down * 20f * Time.deltaTime);
        }
    }

    private void StopWallRun()
    {
        isWallRunning = false;
        rb.useGravity = true;
    }

    private void CheckForWall()
    {
        isWallRight = Physics.Raycast(transform.position, orientation.right, 1f, whatIsWall);
        isWallLeft = Physics.Raycast(transform.position, -orientation.right, 1f, whatIsWall);

        if (!isWallLeft && !isWallRight) StopWallRun();
    }

private bool OnSlope()
{
    if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
    {
        float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
        return angle < maxSloapAngle && angle != 0;
    }
    return false;
}

private Vector3 GetSlopeMoveDir()
{
    return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
}


}
