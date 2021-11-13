using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public Text healthText;
	public Slider healthBar;
	public Image healthImage;
	public float regenerationSpeed = 4;
	public Behaviour[] stuff;
	public float startHealth;
	public Color fullHealthColor = Color.green;
	public Color deadColor = Color.red;
	private float currentHealth;
	private bool dead = false;
	private Animator anim;

	void Awake() 
	{
		anim = GetComponent<Animator> ();
		currentHealth = startHealth;
	}

	void Update() 
	{
		if (dead)
			return;
		healthBar.value = currentHealth / startHealth;
		healthImage.color = Color.Lerp (deadColor, fullHealthColor, currentHealth / startHealth);
		healthText.color = healthImage.color;
		Cursor.lockState = CursorLockMode.Locked;
		if (currentHealth <= 0) 
		{
			dead = true;
			Die ();
		}
		currentHealth += Time.deltaTime * regenerationSpeed;
	}

	void Die() 
	{
		for (int i = 0; i < stuff.Length; i++) 
		{
			stuff [i].enabled = false;
		}
		if (anim != null) 
		{
			anim.SetTrigger ("Die");
		}
		Destroy(gameObject, 4);
	}

	public void TakeDamage(float damage) 
	{
		currentHealth -= damage;
	}
}
