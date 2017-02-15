using UnityEngine;
using System.Collections;
using System;

public class PlayerScript : MonoBehaviour {

    private Rigidbody rgbo;

    public float speed = 50f;
    public float maxSpeed = 3f;
    public float jumpPower = 200f;
    private bool _isGrounded;
    private bool _isDoubleJump;
    private bool _isInvert = false;

    public bool IsInvert
    {
        get { return _isInvert; }
        set { _isInvert = value; }
    }

    public bool IsGrounded
    {
        get { return _isGrounded; }
        set { _isGrounded = value; }
    }

    public bool IsDoubleJump
    {
        get { return _isDoubleJump; }
        set { _isDoubleJump = value; }
    }

    // Use this for initialization
    void Start()
    {
        rgbo = gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded)
            {
                rgbo.AddForce(Vector3.up * jumpPower);
            }
            else
            {
                if(IsDoubleJump)
                {
                    IsDoubleJump = false;
                    rgbo.AddForce(Vector3.up * jumpPower);
                }
            }
                    
        }
    }

    void FixedUpdate()
    {
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rgbo.AddForce(Vector3.back * ((IsInvert ? -h : h)* speed));
        rgbo.AddForce(Vector3.right * ((IsInvert ? -v : v) * speed));

        if (rgbo.velocity.x > maxSpeed)
            rgbo.velocity = new Vector3(maxSpeed, rgbo.velocity.y);
        if (rgbo.velocity.x < -maxSpeed)
            rgbo.velocity = new Vector3(-maxSpeed, rgbo.velocity.y);
        if (rgbo.velocity.z > maxSpeed)
            rgbo.velocity = new Vector3(maxSpeed, rgbo.velocity.y);
        if (rgbo.velocity.z < -maxSpeed)
            rgbo.velocity = new Vector3(-maxSpeed, rgbo.velocity.y);

    }

}
