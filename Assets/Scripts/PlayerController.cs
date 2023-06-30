using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour

{
    private PlayerControls controls;
    private Vector2 movementInput;
    private float normalSpeed = 2f;
    private float runningSpeed= 4f;
    private float speed = 2f;

    private float jumpForce = 5f;
    private bool isGrounded;
    private int jumpNumber;
    public Rigidbody rb;
    public GameObject camHolder;
    public float sensivity;
    public Vector2 move, look;
    public float lookRotation;
    private Animator animator;

    public GameObject skillObject;
    public Transform objectBaslangic;
    public float skillForce = 100f;
    public float skillSize = 3f;

    public GameObject rockToThrow;

    public float runningCooldown = 0f;
    public float skillCooldown = 0f;

    bool haveKey = false;


    private void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Move.performed += moving =>
        {
            movementInput = moving.ReadValue<Vector2>();
            animator.SetBool("isWalking", true);
            
        };
        controls.Player.Move.canceled += moving =>
        {
            movementInput = Vector2.zero;
            animator.SetBool("isWalking", false);
            
        };
        controls.Player.Jump.performed += moving=>
        {
                Jump();
        };
        controls.Player.Run.performed += moving =>
        {
            if(runningCooldown <= 0f)
            {
                animator.SetBool("isRunning", true);
                speed = runningSpeed;
                runningCooldown = 4f;
            }
        };
        controls.Player.Run.canceled += moving =>
        {
            animator.SetBool("isRunning", false);
            speed = normalSpeed;
        };
        controls.Player.Attack.performed += moving =>
        {
            if(skillCooldown <= 0f)
            {
                Skill();
                animator.SetBool("attack", true);
                skillCooldown = 3f;
            }
            
            
        };
        controls.Player.Attack.canceled += moving =>
        {
            animator.SetBool("attack",false);

        };

    }

    private void Skill()
    {
        
        GameObject projectile = Instantiate(skillObject);

        projectile.transform.localScale = new Vector3(skillSize, skillSize, skillSize);
        projectile.transform.position = objectBaslangic.position + new Vector3(0,1,1);
        
        projectile.AddComponent<Rigidbody>();
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        
        if (rb != null)
        {
            rb.AddForce(transform.forward * skillForce + new Vector3(0,3,0), ForceMode.Impulse);
        }
    }
    private void Jump()
    {
        if(isGrounded || jumpNumber > 0) { 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            jumpNumber--;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpNumber = 2;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        controls.Enable();
        animator = GetComponent<Animator>();
        
    }

    private void Update()

    {
        
        Vector3 movement = new Vector3(movementInput.x, 0, movementInput.y);
        transform.position += movement * speed * Time.deltaTime;

        if (runningCooldown > 0)
        {
            runningCooldown -= Time.deltaTime;
        }
        if (skillCooldown > 0)
        {
            skillCooldown -= Time.deltaTime;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Key")
        {
            haveKey = true;
            Destroy(other.gameObject);
        }
    }
    public bool doesHaveKey()
    {
        return haveKey;
    }


}
