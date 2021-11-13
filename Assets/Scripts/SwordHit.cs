using UnityEngine;
using System.Collections;

public class SwordHit : MonoBehaviour {

	public Collider swordCol, swordTrigger;
	public float HitSpeed, enableTime, disableTime;
	private float countdown = 0;
	private Animator anim;

	void Awake() 
	{
		anim = GetComponent<Animator> ();
	}

	void Update() 
	{
		countdown -= Time.deltaTime;
		if (Input.GetButtonDown ("Fire1") && countdown <= 0) 
		{
			Hit ();
		}
	}

	void Hit()
	{
		countdown = HitSpeed;
		anim.SetTrigger ("Attack");
		StartCoroutine (swordThings ());
	}

	IEnumerator swordThings() 
	{
		yield return new WaitForSeconds (enableTime);
		swordCol.enabled = true;
		swordTrigger.enabled = true;
		yield return new WaitForSeconds (disableTime);
		swordCol.enabled = false;
		swordTrigger.enabled = false;
	}
}
