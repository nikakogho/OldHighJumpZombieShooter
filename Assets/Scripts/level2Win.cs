using UnityEngine;
using System.Collections;

public class level2Win : MonoBehaviour {

	public GameObject shatteredBall, portal;
	public float growSpeed, maxSize, shatterTime = 7;
	private GameObject player;
	private float percentage = 0;
	private bool near = false, growing = false, coloring = false;
	private Animator anim;

	void Awake() 
	{
		anim = GetComponent<Animator> ();
	}

	void Update() 
	{
		if (GameObject.FindGameObjectWithTag ("Enemy") == null && near && Input.GetKeyDown("e")) 
	    {
			Level2Win ();
		}
		if (growing)
			GrowPlayer ();
		if (coloring) 
		{
			percentage += Time.deltaTime;
			if (percentage > 1)
				percentage = 1;
			GetComponent<Renderer> ().material.color = Color.Lerp (Color.white, Color.red, percentage);
		}
	}

	void Level2Win() 
	{
		anim.SetTrigger ("clicked");
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.CompareTag ("Player")) 
		{
			near = true;
			player = other.gameObject;
		}
	}

	public void GrowPlayer() 
	{
		if (player.transform.localScale.x < maxSize) 
		{
			growing = true;
		} else
			growing = false;
		player.transform.localScale += new Vector3(growSpeed * Time.deltaTime,growSpeed * Time.deltaTime,growSpeed * Time.deltaTime);
	}

	public void DestroyBall() 
	{
		StartCoroutine (shatter ());
	}

	IEnumerator shatter() 
	{
		coloring = true;
		yield return new WaitForSeconds (shatterTime);
		Instantiate (shatteredBall, transform.position, transform.rotation);
		portal.SetActive (true);
		Destroy (gameObject);
	}
}
