using UnityEngine;

public class SoldierAnimation : MonoBehaviour {

	private Animator anim;
    bool walking;
    
    float h;
    float v;
    
	void Awake() 
	{
		walking = false;
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate () 
	{
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        Animate();
	}

    void Animate()
    {
        walking = h != 0 || v != 0;
        anim.SetBool("IsWalking", walking);
        if(Bullet.shooting)
        {
            anim.SetTrigger("IsShooting");
            Bullet.shooting = false; 
        }
    }
}
