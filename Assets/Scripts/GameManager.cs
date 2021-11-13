using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static int currentLevel = 1;

	[Header("Level1Stuff")]
	public GameObject endCam;
	public GameObject winCam;
	public Text HighScoreText;
	[Header("Level2stuff")]
	public GameObject player;
	[HideInInspector]public GameObject clone;
	[Header("Level3Stuff")]
	public GameObject soldier;
	public GameObject footman;
	public GameObject chooseCamera;
	public Transform spawnPoint;

    public void Lose() 
	{
		endCam.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
	}

	public void Win() 
	{
		winCam.SetActive (true);
		Cursor.lockState = CursorLockMode.None;
	}

	public void NextLevel() 
	{
		currentLevel++;
		SceneManager.LoadScene ("level" + currentLevel.ToString ());
	}

	public void SpawnPlayer() 
	{
		clone = Instantiate (player, transform.position, transform.rotation);
	}

	public void Reset() 
	{
		PlayerPrefs.DeleteAll ();
		if(HighScoreText != null)
		HighScoreText.text = "HighScore : 0"; 
	}

	public void Restart() 
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void Exit() 
	{
		Application.Quit ();
	}

	public void ChooseSoldier() 
	{
		Instantiate (soldier, spawnPoint.position, spawnPoint.rotation);
		chooseCamera.SetActive (false);
	}

	public void ChooseFootman() 
	{
		Instantiate (footman, spawnPoint.position, spawnPoint.rotation);
		chooseCamera.SetActive (false);
	}
}
