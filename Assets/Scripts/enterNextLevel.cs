using UnityEngine;

public class enterNextLevel : MonoBehaviour {

	void OnTriggerEnter(Collider other) 
	{
		if (other.CompareTag ("Player")) 
		{
			FindObjectOfType<GameManager> ().NextLevel ();
		}
	}
}
