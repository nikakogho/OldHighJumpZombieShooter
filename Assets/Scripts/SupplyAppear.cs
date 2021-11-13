using UnityEngine;

public class SupplyAppear : MonoBehaviour {

	private int amount = 0;
	public GameObject Packs;
	public GameObject SpawnPoints;
	private Transform[] ts;
	private Transform[] spawnPoints;
	public float spawnTime = 1.5f;
	private float countdown;

	void Awake() 
	{
		ts = Packs.transform.GetComponentsInChildren<Transform> ();
		spawnPoints = SpawnPoints.GetComponentsInChildren<Transform> ();
		countdown = spawnTime;
	}

	void Update() 
	{
		countdown -= Time.deltaTime;
		if (countdown <= 0) 
		{
			if(amount > 0)
			Spawn ();
		}
	}

	void Spawn() 
	{
		amount--;
		countdown = spawnTime;

		int s = Random.Range (0, spawnPoints.Length - 1);
		int p = Random.Range (0, ts.Length);

		GameObject so = ts [p].gameObject;

		Instantiate (so, spawnPoints [s].position, spawnPoints [s].rotation);
	}

	public void WavePacks(int Amount, float doTime) 
	{
		amount = Amount;
		spawnTime = doTime;
	}
}
