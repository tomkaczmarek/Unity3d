using UnityEngine;
using System.Collections;

public class SmoothCamera : MonoBehaviour {

    public GameObject player;
    private Vector2 velocity;

    public float smoothTimeX;
    public float smoothTimeY;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
        float posx = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posy = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeX);

        transform.position = new Vector3(posx, posy, transform.position.z);
    }
}
