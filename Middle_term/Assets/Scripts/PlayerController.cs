using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12.0f;
    public float gravity = -9.81f;
    public float jumpHeight = 3.0f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Vector3 velocity;
    bool IsGrounded;

    private void Start()
    {
        DestructibleObject player = GetComponent<DestructibleObject>();
        ServiceLocator.Get<GameManager>().SetHealthBar(player.MaxHealth);
        ServiceLocator.Get<GameManager>().UpdateHealthBar(player.CurrentHealth);
        DontDestroyOnLoad(gameObject);
        
    }
    // Update is called once per frame
    void Update()
    {
        
        Move();

    }

    //private void FixedUpdate()
    //{
    //    Move();


    //}

    private void Move()
    {
        IsGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (IsGrounded && velocity.y < 0.0f)
        {
            velocity.y = -2.0f;

        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);

        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


    }
    //private void Jump()
    //{
    //    float JumpVal = Input.GetKeyDown(KeyCode.Space) ? jumpForce : 0.0f;

    //    switch (_jumpState)
    //    {
    //        case JumpState.Grounded:
    //            if (JumpVal > 0.0f)
    //            {
    //                _jumpState = JumpState.Jumping;
    //            }
    //            break;
    //        case JumpState.Jumping:
    //            JumpVal = 0.0f;
    //            Debug.Log("JumpState: " + _jumpState.ToString());
    //            break;

    //    }
    //    Vector3 jump = new Vector3(0.0f, JumpVal, 0.0f);
    //    rb.AddForce(jump);

    //}
    //private void OnCollisionEnter(Collision collision)
    //{

    //    if (_jumpState == JumpState.Jumping && collision.gameObject.CompareTag("Ground"))
    //    {
    //        _jumpState = JumpState.Grounded;
    //    }
    //}

    //private void StopTheGame()
    //{
    //    Time.timeScale = 0;

    //}








}
