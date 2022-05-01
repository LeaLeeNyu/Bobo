using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTestInput : MonoBehaviour
{
    public CharacterController controller;

    public float walkSpeed = 5.0f;
    public Vector2 moveInput;
    private float xMove;
    private float zMove;

    private float faceDirection;

    public float jumpForce = 5.0f;
    public float jumpFromGroundForce = 2.0f;
    private bool isJump = false;
    private bool onGround;
    public bool spacePressed = false;

    public bool isInGround = true;

    private Rigidbody boboRB;
    public Animator boboAnimator;
    private MeshCollider headCollider;
    private CapsuleCollider boboCollider;


    private int shakeNum = 0;

    private void Awake()
    {

    }

    private void Start()
    {
        boboRB = GetComponentInParent<Rigidbody>();
        boboAnimator = GetComponent<Animator>();
        headCollider = GetComponentInParent<MeshCollider>();
        boboCollider = GetComponentInParent<CapsuleCollider>();
    }

    private void Update()
    {
        //get jump input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressed = true;
        }

        //get walk input
        xMove = Input.GetAxisRaw("Horizontal");
        zMove = Input.GetAxisRaw("Vertical");
        //faceDirection = Input.GetAxisRaw("Horizontal");


    }

    private void FixedUpdate()
    {
        Jump();
        SwitchAni();
        Walk();
    }

    public void Walk()
    {
        Vector3 walkDirection = new Vector3(xMove, 0f, zMove).normalized;

        if (walkDirection.magnitude >= 0.1f)
        {
            boboRB.AddForce(walkDirection * walkSpeed, ForceMode.Impulse);

            // turn the chracter's face direction
            float targetAngle = Mathf.Atan2(walkDirection.x, walkDirection.z) *Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
        }

        //control the walk function
        boboAnimator.SetFloat("walking", walkDirection.magnitude);

    }


    //When player press spacebar, bobo will jump
    public void Jump()
    {
        if (spacePressed && !isJump)
        {
            boboRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);           
            isJump = true;

            //Control the Ani;
            boboAnimator.SetBool("jumping", true);
            boboAnimator.SetBool("idle", false);
        }       
    }

    private void SwitchAni()
    {
        //if bobo is jumping, and y velocity lower than 0, start falling ani
        if (boboAnimator.GetBool("jumping"))
        {
            if (boboRB.velocity.y < 0)
            {
                boboAnimator.SetBool("jumping", false);
                boboAnimator.SetBool("falling", true);
            }
        }       
        //if bobo is not jumping and moving, she stand on the ground and start idle animation
        else if (onGround)
        {
            spacePressed = false;
            Debug.Log(spacePressed);

            boboAnimator.SetBool("falling", false);
            boboAnimator.SetBool("idle", true);

            //spacePressed to balance the time interval between FixUpdate and Update
            //If put this line of code in jump() and player quickly press the space twice, the bobo will re-jump as soon as it collides with the ground            

            isJump = false;
        }

        //if bobo is not jumping but moving       
        //float moveAni = Mathf.Abs(boboRB.velocity.x) + Mathf.Abs(boboRB.velocity.z);
        //boboAnimator.SetFloat("walking", moveAni);

    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }


    public void Shake()
    {
        if (isInGround && boboCollider.isTrigger)
        {
            shakeNum += 1;
            boboAnimator.SetBool("shaking", true);
            boboAnimator.SetInteger("shakeNum", shakeNum);

            //When player press shake button three times, the bobo will jump to the ground
            if (shakeNum == 3)
            {
                boboRB.AddForce(Vector3.up * jumpFromGroundForce);
                boboAnimator.SetBool("jumping", true);
            }
        }
        else
        {
            Debug.Log("Is not under the ground!");
        }
    }

    public void InToGround()
    {
        boboCollider.isTrigger = true;
        isInGround = true;
    }





}
