using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float reloadTime = 1.5f;
	public int maxAmmo = 30;
	private int currentAmmo;
	public Text currentAmmoText;
	public Text totalAmmoText;
	public Transform FirePoint;
	public Rigidbody bullet;
    public float bulletPush;
    public float bulletlife = 3;
    public float fire_rate = 0.5f;
    public int bullets = 100;
    public static bool shooting;
	private float countdown = 0;
	bool isReloading = false;

	void Awake() 
	{
		Cursor.lockState = CursorLockMode.Locked;
		currentAmmo = maxAmmo;
	}

	IEnumerator reloading()
	{
		isReloading = true;
		yield return new WaitForSeconds (reloadTime);
		if (bullets >= maxAmmo) {
			currentAmmo = maxAmmo;
		} else
			currentAmmo = bullets;
		bullets -= currentAmmo;
		isReloading = false;
	}

	void Reload() 
	{
		StartCoroutine (reloading ());
	}

    void Update()
	{   
		currentAmmoText.text = currentAmmo.ToString ();
		totalAmmoText.text = bullets.ToString ();
		if (Input.GetButton("Fire1") && countdown<=0 && !isReloading)
        {
			if (currentAmmo > 0) {
				Rigidbody cloneRb = Instantiate (bullet, FirePoint.position, FirePoint.rotation) as Rigidbody;

				cloneRb.transform.Rotate (90, 0, 0);
				cloneRb.velocity = FirePoint.forward * bulletPush;

				Destroy (cloneRb.gameObject, bulletlife);
				countdown = fire_rate;
				currentAmmo--;
				shooting = true;
			} else if (bullets > 0) 
			{
				Reload ();
			}
        }
        countdown -= Time.deltaTime;
    }

	void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Zombie")
        {
            Debug.Log("Shot!");
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Head")
        {
            Debug.Log("HeadShot!");
            Destroy(other.gameObject);
        }
    }
}
