using UnityEngine;

public class footmanAnimations : MonoBehaviour {

	private Animator anim;

	void Awake() 
	{
		anim = GetComponent<Animator> ();
	}

	void Update() 
	{
		anim.SetBool ("IsWalking", Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0);
	}
}
