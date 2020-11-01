using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum JumpState
    {
        Grounded,
        Jumping

    }
    public float speed = 10.0f;
    public float jumpForce = 100.0f;
    public int playerPoints = 0;
    //private int Level = 1;
    //private bool IsOntheGround = true;
    private Rigidbody rb;
    private JumpState _jumpState = JumpState.Grounded;
    // Start is called before the first frame update



    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        if (transform.position.y < -10.0f)
        {
            //ServiceLocator.Get<UIManager>().SetEndUi(0);
            Invoke("StopTheGame", 0.3f);
        }
    }

    private void FixedUpdate()
    {
        Move();

    }

    private void Move()
    {
        float moveHorizaontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(moveHorizaontal * speed, 0.0f, moveVertical * speed);

        rb.AddForce(movement);


    }
    private void Jump()
    {
        float JumpVal = Input.GetKeyDown(KeyCode.Space) ? jumpForce : 0.0f;

        switch (_jumpState)
        {
            case JumpState.Grounded:
                if (JumpVal > 0.0f)
                {
                    _jumpState = JumpState.Jumping;
                }
                break;
            case JumpState.Jumping:
                if (JumpVal > 0.0f)
                {
                    JumpVal = 0.0f;
                }
                break;
        }
        Vector3 jump = new Vector3(0.0f, JumpVal, 0.0f);
        rb.AddForce(jump);

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (_jumpState == JumpState.Jumping  && collision.gameObject.CompareTag("Ground"))
        {
            _jumpState = JumpState.Grounded;
        }
    }
   
    private void StopTheGame()
    {
        Time.timeScale = 0;

    }






}
