using UnityEngine;

public class bulletMove : MonoBehaviour {

	public GameObject blood;
	public float bloodDestroyTime = 2;
	public float damage = 2.5f;

	void OnCollisionEnter(Collision col) 
	{
		Collider other = col.collider;
		enemyHealth health = other.GetComponentInParent<enemyHealth> ();
		LastShot lastShot = other.GetComponent<LastShot> ();
		if (health != null && health.transform.CompareTag("Zombie")) 
		{
			health.shotAt = lastShot.shot.ToString ();
			if (other.CompareTag ("Head")) {
				health.takeDamage (health.startHealth);
			} else
				health.takeDamage (damage);
			Destroy(Instantiate (blood, transform.position, transform.rotation), bloodDestroyTime);
		}
		Destroy (gameObject);
	}
}
