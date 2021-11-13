//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    public GameObject firePoint;
    public GameObject missile;
    public float missileLife = 3f;
    public int missiles = 5;
    public float fire_rate = 2;
    public float missilePush;
    float countdown;
    void Start()
    {
        countdown = 0;
    }
	void Update () {
        if (Input.GetButton("Fire1")&&countdown<=0)
        {
            if (missiles > 0)
            {
                GameObject temporary_missile;
                temporary_missile = Instantiate(missile, firePoint.transform.position, firePoint.transform.rotation) as GameObject;

                temporary_missile.transform.Rotate(Vector3.left * 90);

                Rigidbody temporary_RigidBody;
                temporary_RigidBody = temporary_missile.GetComponent<Rigidbody>();

                temporary_RigidBody.AddForce(transform.forward * missilePush * Time.deltaTime);

                Destroy(temporary_missile, missileLife);
                countdown = fire_rate;
                missiles--;
            }
            else Debug.Log("No more rockets left");
        }

    }
    public void Count()
    {
        countdown--;
    }
}
