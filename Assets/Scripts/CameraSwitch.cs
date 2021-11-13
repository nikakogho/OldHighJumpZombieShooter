//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    public Camera FirstPersonCamera;
    public Camera ThirdPersonCamera;
    int switcher; 
	void Start () {
        switcher = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
            switcher *= -1;
        if(switcher ==1 )
        {
            FirstPersonCamera.enabled = true;
            ThirdPersonCamera.enabled = false;
        }
        else
        {
            FirstPersonCamera.enabled = false;
            ThirdPersonCamera.enabled = true;
        }
    }
}
