using UnityEngine;
using UnityEngine.UI;

public class WaveLauncher : MonoBehaviour {

	public Text HighScoreText;
	public Text scoreWave;
	public GameObject SpawnPoints;
	public GameObject Zombie;
	public wave[] waves;
	[SerializeField]private int currentWave = 0;
	private float countdown = 0;
	private int enemiesLeft = 0;
	private Transform[] spawnPoints;
	private bool justStarted = true;
	private float waitTime = 0;

	void Awake() 
	{
		spawnPoints = SpawnPoints.GetComponentsInChildren<Transform> ();
	}

	void Update() 
	{
		
		if (justStarted) 
		{
			justStarted = false;
			waitTime = waves [currentWave].waitTime;
			enemiesLeft = waves [currentWave].totalEnemies;
			FindObjectOfType<SupplyAppear> ().WavePacks (waves [currentWave].amount, waves [currentWave].packSpawnTime);
		}
		if(enemiesLeft <= 0)
		waitTime -= Time.deltaTime;
		countdown -= Time.deltaTime;
		if (enemiesLeft == 0 && (GameObject.FindGameObjectWithTag ("Zombie") == null || waitTime <= 0)) 
		{
			NextWave ();
		}
		if (countdown <= 0) 
		{
			Spawn ();
		}
		if (GameObject.FindGameObjectWithTag ("Player") == null) 
		{
			Lose ();
		}
	}

	void NextWave() 
	{
		currentWave++;
		foreach (GameObject remain in GameObject.FindGameObjectsWithTag("Zombie"))
		{
			Destroy (remain);
		}
		if (currentWave > PlayerPrefs.GetInt ("HighScore", 0)) 
		{
			PlayerPrefs.SetInt ("HighScore", currentWave);
		}

		justStarted = true;
		if (waves.Length < currentWave) 
		{
			Win ();
		}
	}

	void Win() 
	{
		FindObjectOfType<GameManager> ().Win ();
		HighScoreText.text = "Victory";
		Destroy(GameObject.FindGameObjectWithTag("Player"));
		Destroy (this);
	}

	void Lose() 
	{
		FindObjectOfType<GameManager> ().Lose ();
		HighScoreText.text = "HighScore : " + PlayerPrefs.GetInt ("HighScore", 0).ToString ();
		scoreWave.text = "Waves Survived : " + currentWave.ToString ();
		Destroy(GameObject.FindGameObjectWithTag("Player"));
		Destroy (this);
	}

	void Spawn() 
	{
		countdown = waves [currentWave].spawnRate;
		if (waves [currentWave].hasZombies && enemiesLeft > 0) 
		{
			int place = Random.Range (0, spawnPoints.Length);

			Instantiate (Zombie, spawnPoints [place].position, spawnPoints [place].rotation);
			enemiesLeft--;
		}
	}
}
