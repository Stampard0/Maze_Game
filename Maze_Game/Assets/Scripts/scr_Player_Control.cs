using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Player_Control : MonoBehaviour
{
    private CharacterController CharControl;
    private Vector3 input;
    [SerializeField] float crouchSpeedMultiplier = 0.5f; //crouch speed
    [SerializeField] float jumpForce = 0.5f; // jump force
    [SerializeField] int gravity = 1;
    [SerializeField] int speed = 1;
    private bool crouching = false; //crouch bool
    //private bool isGrounded = false; //not on ground

    // Start is called before the first frame update
    void Start()
    {
        CharControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Read input
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        //jump = Input.GetAxis("Jump");
        Vector3 motion = Vector3.zero;
        //Left/right movement
        if (input.x > 0)
        {
            transform.forward = Vector3.right;
            motion = transform.forward.normalized;
        }
        if (input.x < 0)
        {
            transform.forward = -Vector3.right;
            motion = transform.forward.normalized;
        }
        //Forward/backward movement
        if (input.y > 0)
        {
            transform.forward = Vector3.forward;
            motion = transform.forward.normalized;
        }
        if (input.y < 0)
        {
            transform.forward = -Vector3.forward;
            motion = transform.forward.normalized;
        }
        if (CharControl.isGrounded)
        {
            if (Input.GetAxis("Jump") > 0)
            {

            }
            if (Input.GetAxis("Fire3") > 0) //Need to use something different
            {

            }

            //Apply movement to controller
            CharControl.Move(motion.normalized * speed * Time.deltaTime);
            //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
