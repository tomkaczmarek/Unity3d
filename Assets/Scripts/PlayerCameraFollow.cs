using UnityEngine;
using System.Collections;

public class PlayerCameraFollow : MonoBehaviour {

    private Camera mainCamera;
    private GameObject player;
    public float distance = 40;
    public float cameraHeight = 3;
    private Vector3 playerPosition;
    private bool _invertCamera = false;

    public bool IsInvert
    {
        get { return _invertCamera; }
        set { _invertCamera = value; }
    }

	// Use this for initialization
	void Start ()
    {
        mainCamera = GetComponent<Camera>();
        player = GameObject.Find("Player");
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerPosition = player.transform.transform.position;       
        mainCamera.transform.position = new Vector3(IsInvert ? playerPosition.x + distance : playerPosition.x - distance , playerPosition.y + cameraHeight, playerPosition.z);     
	
	}
}
