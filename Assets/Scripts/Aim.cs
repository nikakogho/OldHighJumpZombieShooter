using UnityEngine;

public class Aim : MonoBehaviour {

	public Camera cam;
	/*public float minimumY = -60;
	public float maximumY = 60;

	public float sensitivityY = 10;

	float rotationY = 0;*/

	void Update() 
	{
		if(Input.GetMouseButtonDown(1)) 
		{
			cam.enabled = !cam.enabled;
		}


		/*
		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

		transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, transform.localEulerAngles.z);
		*/
	}
}
