using UnityEngine;

public class enemyHealth : MonoBehaviour {

	private bool dead = false;
	public float startHealth = 20, deathTime = 5;
	[HideInInspector]public string shotAt;
	private Animator anim;
	[SerializeField]private float currentHealth;

	void Awake() 
	{
		anim = GetComponent<Animator> ();
		currentHealth = startHealth;
	}

	void Update() 
	{
		if (dead)
			return;
		if (currentHealth <= 0) 
		{
			Die ();
		}
	}

	void Die() 
	{
		if (GetComponent<Attack> () != null)
			GetComponent<Attack> ().enabled = false;
		else if (GetComponent<FootmanAttack> () != null)
			GetComponent<FootmanAttack> ().enabled = false;
		else
			GetComponent<ShooterAttack> ().enabled = false;
		dead = true;
		if (CompareTag ("Zombie"))
			anim.SetTrigger (shotAt);
		else
			anim.SetTrigger ("Die");
		Destroy (gameObject, deathTime);
	}

	public void takeDamage(float damage) 
	{
		currentHealth -= damage;
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.CompareTag("Sword")) 
		{
			takeDamage (other.GetComponent<hit>().damage);
		}
	}
}
