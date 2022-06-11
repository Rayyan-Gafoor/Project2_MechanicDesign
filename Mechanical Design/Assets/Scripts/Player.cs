using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float MoveSpeed = 6f;
    public Transform player__mesh;
    [SerializeField] float NormalStrayfing = 6f;
    float horiMove;
    float vertMove;
    Vector3 moveDir;
    Vector3 slopeMoveDir;
    Rigidbody rb;

    //Jump Variable
    [SerializeField] float Jumpforce = 15f;
    [SerializeField] float AirStrayfing = 2f;
    [SerializeField] float AirMoveMulti=0.1f;

    //Crouch Variables

    //Ground
    bool isGrounded;
    [SerializeField] LayerMask GroundMask;
    [SerializeField] Transform GroundCheck;
    float groundDis = 0.4f;
    float PlayerHeight = 2f;

    //Slope Control
    RaycastHit slopeHit;

    //Charcter Control
    [Header("Character Controller Substitute")]
    [SerializeField] GameObject Ray1;
    [SerializeField] GameObject Ray2;
    [SerializeField] float MaxStepHeight = 0.3f;
    [SerializeField] float Smooth = 0.1f;

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, PlayerHeight / 2 + 0.5f))
        {
            if (slopeHit.normal != Vector3.up)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
    private void Awake()
    {
        Ray1.transform.position = new Vector3(Ray1.transform.position.x, MaxStepHeight, Ray1.transform.position.z);

    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDis, GroundMask);
        Debug.Log(isGrounded);
        PlayerInput();
       // Strayfing();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Try Jump");
            Jump();
        }
        slopeMoveDir = Vector3.ProjectOnPlane(moveDir, slopeHit.normal);
    }
    private void FixedUpdate()
    {
        Cursor.lockState = CursorLockMode.Locked;
        MovePlayer();
        //Climb();
    }


    // my functions 
    void PlayerInput()
    {
        horiMove = Input.GetAxisRaw("Horizontal");
        vertMove = Input.GetAxisRaw("Vertical");
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        moveDir = forward * vertMove + right * horiMove;
        if (moveDir != new Vector3(0, 0, 0))
        {
            //player__mesh.rotation = Quaternion.LookRotation(moveDir);
        }
    }
    void MovePlayer()
    {
        if (isGrounded && !OnSlope())
        {
            rb.AddForce(moveDir.normalized * MoveSpeed , ForceMode.Acceleration);
        }
        else if (isGrounded && OnSlope())
        {
            rb.AddForce(slopeMoveDir.normalized * MoveSpeed, ForceMode.Acceleration);
        }
        else if (!isGrounded)
        {
            rb.AddForce(moveDir.normalized * MoveSpeed * AirMoveMulti, ForceMode.Acceleration);
        }
    }
    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(transform.up * Jumpforce, ForceMode.Impulse);
        Debug.Log("Player Jump");
    }
    void Strayfing()
    {
        if (isGrounded)
        {
            rb.drag = NormalStrayfing;
        }
        else
        {
            rb.drag = AirStrayfing;
        }

    }
    void Climb()
    {
        RaycastHit hitLower;
        if (Physics.Raycast(Ray2.transform.position, transform.TransformDirection(Vector3.forward), out hitLower, 0.1f))
        {
            RaycastHit hitUpper;
            if (!Physics.Raycast(Ray1.transform.position, transform.TransformDirection(Vector3.forward), out hitUpper, 0.2f))
            {
                rb.position -= new Vector3(0f, -Smooth, 0f);
            }

        }

        RaycastHit hitLowerAngle;
        if (Physics.Raycast(Ray2.transform.position, transform.TransformDirection(1.5f, 0, 1), out hitLowerAngle, 0.1f))
        {
            RaycastHit hitUpperAngle;
            if (!Physics.Raycast(Ray1.transform.position, transform.TransformDirection(1.5f, 0, 1), out hitUpperAngle, 0.2f))
            {
                rb.position -= new Vector3(0f, -Smooth, 0f);
            }

        }
        RaycastHit hitLowerNegAngle;
        if (Physics.Raycast(Ray2.transform.position, transform.TransformDirection(-1.5f, 0, 1), out hitLowerAngle, 0.1f))
        {
            RaycastHit hitUpperNegAngle;
            if (!Physics.Raycast(Ray1.transform.position, transform.TransformDirection(-1.5f, 0, 1), out hitUpperNegAngle, 0.2f))
            {
                rb.position -= new Vector3(0f, -Smooth, 0f);
            }

        }
    }
    
}
