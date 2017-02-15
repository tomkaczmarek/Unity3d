using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {

    private PlayerScript player;

	// Use this for initialization
	void Start ()
    {
        player = gameObject.GetComponentInParent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        player.IsGrounded = true;
        player.IsDoubleJump = false;
    }

    void OnTriggerStay(Collider col)
    {
        player.IsGrounded = true;
        player.IsDoubleJump = false;
    }

    void OnTriggerExit(Collider col)
    {
        player.IsGrounded = false;
        player.IsDoubleJump = true;
    }
}
