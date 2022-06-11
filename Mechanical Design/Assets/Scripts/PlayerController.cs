using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jump__force;
    public float hop__force;
    Rigidbody rb;

    public float check__distance;
    public Transform groud__check;
    public LayerMask groudn__mask;

    public Transform player__mesh;

    public bool can__jump;
    public bool can__move;

    public float ground__strayfing = 6f;
    public float air__strayfing = 6f;
    public float ground__mass = 0;
    public float air__mass = 0;
    public Vector3 gravity__input;

    ShadowWalk shadow__walker;
    AnimationSub anime__sub;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        shadow__walker = GetComponent<ShadowWalk>();
        anime__sub = GetComponent<AnimationSub>();
    }

    // Update is called once per frame
    private void Update()
    {
        GravityControl();

        can__jump = Physics.CheckSphere(groud__check.position, check__distance, groudn__mask);
       if (can__jump && Input.GetButtonDown("Jump") && !shadow__walker.is__shadow)
        {
            rb.velocity = Vector3.up * jump__force;
        }
    }
    void FixedUpdate()
    {
        Cursor.lockState = CursorLockMode.Locked;

        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 Movedirection = forward * dirY + right * dirX;
        rb.velocity = new Vector3(Movedirection.x * speed, rb.velocity.y, Movedirection.z * speed);

        if(Movedirection!= new Vector3(0, 0, 0))
        {
            //StartCoroutine(anime__sub.Walk());
            player__mesh.rotation = Quaternion.LookRotation(Movedirection); 
        }
    }
    void Strayfing()
    {
        if (can__jump)
        {
            rb.drag = ground__strayfing;
        }
        else
        {
            rb.drag = air__strayfing;
        }

    }
    void GravityControl()
    {
        if (can__jump)
        {
            rb.drag = ground__strayfing;
            rb.mass = ground__mass;
        }
        else
        {
          
            if (!can__jump)
            {
                rb.drag = air__strayfing;
                rb.mass = air__mass;
                Physics.gravity = gravity__input;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groud__check.transform.position, check__distance);
    }
}
