using UnityEngine;
using System.Collections;
using Assets.Scripts.Triggers.Helpers;

public class FallReturnTrigger : MonoBehaviour {


    private GameObject player;
    private PlayerCameraFollow cameraFollow;
    private PlayerScript playerScript;
    public Camera camera;

    // Use this for initialization
    void Start () {

        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerScript>();
        cameraFollow = camera.GetComponent<PlayerCameraFollow>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider col)
    {
        ObjectChanger changer = new ObjectChanger(player, playerScript, cameraFollow, camera, null, true);
        changer.Change();
        player.transform.position = new Vector3(-4f, 3f, -1f);

    }
}
