using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Player_Control : MonoBehaviour
{
    private CharacterController CharControl;
    private Vector3 motion;
    private float currentSpeed = 0;
    private float velocity = 0;
    private float gravity = 3.5f; // gravity
    [Range(1f, 10f)] public float speed = 2f; // normal player speed
    [Range(0.1f, 1f)] public float crouchSpeedMultiplier = 0.5f; //crouch speed
    [SerializeField] float jumpForce = 1.5f; // jump force
    private bool crouching = false; //crouch bool
    private bool isGrounded = false; //not on ground
    private float sprintSpeedMultiplier = 2f;
    private bool sprinting = false; //sprinting bool = not sprinting

    // Awake is called before start method
    private void Awake()
    {
        CharControl = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = speed;
    }

    private void FixedUpdate()
    {
        isGrounded = CharControl.isGrounded;
        motion = Vector3.zero;

        if (isGrounded == true)
        {
            velocity = -gravity * Time.deltaTime;
        }
        else
        {
            velocity -= gravity * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Read input
        //input.x = Input.GetAxisRaw("Horizontal");
        //input.y = Input.GetAxisRaw("Vertical");
        //jump = Input.GetAxis("Jump");
        //Vector3 motion = Vector3.zero;
        //Left/right movement
        //if (input.x > 0){transform.forward = Vector3.right; motion = transform.forward.normalized;}
        //if (input.x < 0){transform.forward = -Vector3.right; motion = transform.forward.normalized;}
        
        //Forward/backward movement
        //if (input.y > 0){transform.forward = Vector3.forward; motion = transform.forward.normalized;}
        //if (input.y < 0){transform.forward = -Vector3.forward; motion = transform.forward.normalized;}
        
        if (CharControl.isGrounded)
        {
            if (Input.GetAxis("Jump") > 0) //checks if the buttons alocated to the "Jump" input are being used
            {
                velocity = jumpForce * currentSpeed; //makes the player character jump
            }
            if (Input.GetAxis("Crouch") > 0) //checks if the buttons alocated to the "Crouch" input are being used
            {
                //ApplyCrouch();
                crouching = true; currentSpeed = speed * crouchSpeedMultiplier; CharControl.height = 1; //Debug.Log("Crouching");
                
            }
            if (Input.GetAxis("Crouch") <= 0)
            {
                crouching = false; currentSpeed = speed; CharControl.height = 2; //Debug.Log("Not Crouching");
            }
            if (Input.GetAxis("Sprint") > 0)
            {
                if (crouching == true)
                {
                    //ApplyCrouch();
                }
                else
                {
                    currentSpeed = speed * sprintSpeedMultiplier;
                }
            }
            if (Input.GetAxis("Sprint") <= 0)
            {
                currentSpeed = speed;
            }

            //Apply movement to controller
            //CharControl.Move(motion.normalized * speed * Time.deltaTime);
            //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        ApplyMovement();
    }
    //void ApplyCrouch()
    //{
        //if (crouching == true){crouching = false; currentSpeed = speed; CharControl.height = 2; Debug.Log("Not Crouching");}
        //if (crouching == false){crouching = true; currentSpeed = speed * crouchSpeedMultiplier; CharControl.height = 1; Debug.Log("Crouching");}
    //}

    void ApplyMovement()
    {
        float inputY = Input.GetAxisRaw("Horizontal") * currentSpeed;
        float inputX = Input.GetAxisRaw("Vertical") * currentSpeed;
        motion += transform.forward * inputX * Time.deltaTime;
        motion += transform.right * inputY * Time.deltaTime;
        motion.y += velocity * Time.deltaTime;
        CharControl.Move(motion);
    }
}
