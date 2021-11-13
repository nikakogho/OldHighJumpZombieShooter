using UnityEngine;

public class FootmanAttack : MonoBehaviour {

	public float hitSpeed;
	public float seeRange, nearRange, attackRange;
	public float moveSpeed, runSpeed, rotateSpeed;
	public float damage;

	private Animator anim;
	private float countdown = 0;
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
		countdown -= Time.deltaTime;
		target = Target.transform;
		Vector3 dir = target.position - transform.position;

		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (dir), rotateSpeed * Time.deltaTime);
		if (Vector3.Distance (transform.position, target.position) <= attackRange) 
		{
			if (countdown <= 0) 
			{
				countdown = hitSpeed;
				target.GetComponent<PlayerHealth> ().TakeDamage (damage);
				anim.SetTrigger ("Hit");
			}
		} else if (Vector3.Distance (transform.position, target.position) <= nearRange)
		{
			transform.Translate (Vector3.forward * runSpeed * Time.deltaTime);
			anim.SetBool ("Near", true);
		} else if (Vector3.Distance (transform.position, target.position) <= seeRange) 
		{
			transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
			anim.SetBool ("Near", true);
		} else 
		{
			anim.SetBool ("Near", false);
		}
	}


	void OnDrawGizmosSelected() 
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (transform.position, seeRange);
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, nearRange);
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, attackRange);
	}
}
