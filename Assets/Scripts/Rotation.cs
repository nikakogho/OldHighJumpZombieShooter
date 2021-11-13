using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public float moveSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;

    private CharacterController controller;
    private float gravity = -9.81f;

	void Start ()
    {
        controller = GetComponent<CharacterController>();
	}
	

	void Update ()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0);
        //transform.Rotate(Input.GetAxis("Mouse Y") * mouseSensitivity, 0, 0);
        float verticalMotion = Input.GetAxis("Vertical") * moveSpeed;
        float horizontalMotion = Input.GetAxis("Horizontal") * moveSpeed;
        Vector3 motion = new Vector3(horizontalMotion, gravity, verticalMotion);

        motion = transform.TransformDirection(motion);
        controller.Move(motion * Time.deltaTime);
	}
}
