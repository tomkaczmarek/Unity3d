using UnityEngine;
using System.Collections;
using Assets.Scripts.Triggers.Helpers;

public class CameraChangerTrigger : MonoBehaviour {

    public Camera camera;
    public GameObject mainObject;
    public float rotationAnchor = 180;
    private PlayerCameraFollow cameraFollow;
    private PlayerScript player;

    void Start()
    {
        cameraFollow = camera.GetComponent<PlayerCameraFollow>();
        player = mainObject.GetComponent<PlayerScript>();
    }
	
	// Update is called once per frame
	void OnTriggerEnter(Collider col)
    {
        ChangeComponent();
    }

    private void ChangeComponent()
    {
        ObjectChanger changer = new ObjectChanger(mainObject, player, cameraFollow, camera, rotationAnchor, false);
        changer.Change();
    }
}
