using UnityEngine;

public class Attack : MonoBehaviour {

	public float seeRange, attackRange, damage, hitSpeed, moveSpeed, rotateSpeed;
	private float countdown = 0;
	private Animator anim;
	private Transform target;

	void Awake() 
	{
		anim = GetComponent<Animator> ();
	}

	void Update() 
	{
		GameObject Target = GameObject.FindGameObjectWithTag ("Player");
		if (Target == null)
			return;
		target = Target.transform;

		if (Vector3.Distance (transform.position, target.position) <= attackRange) 
		{
			countdown -= Time.deltaTime;
			if (countdown <= 0) 
			{
				countdown = hitSpeed;
				attack ();
			}
		} else if (Vector3.Distance (transform.position, target.position) <= seeRange) 
		{
			WalkToTarget ();
		}
	}

	void attack() 
	{
		anim.SetTrigger ("Attack");
		PlayerHealth health = target.GetComponent<PlayerHealth> ();
		if (health == null)
			return;
		health.TakeDamage (damage);
	}

	void WalkToTarget() 
	{
		Vector3 direction = target.position - transform.position;

		direction.y = 0;

		transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
		if (transform.rotation != Quaternion.LookRotation (direction)) 
		{
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
		}
	}

	void OnDrawGizmosSelected() 
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, attackRange);
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, seeRange);
	}
}
