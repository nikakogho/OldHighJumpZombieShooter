using UnityEngine;

public class Collect : MonoBehaviour {

	public int bullets;
	public float health;

	void OnCollisionEnter(Collision col) 
	{
		Collider other = col.collider;

		if (other.CompareTag ("Player")) 
		{
			other.GetComponentInChildren<Bullet> ().bullets += bullets;
			other.GetComponent<PlayerHealth> ().TakeDamage (-health);
			Destroy (gameObject);
		}
	}
}
