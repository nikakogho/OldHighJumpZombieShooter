using UnityEngine;

public class destroy : MonoBehaviour {

	void OnTriggerEnter(Collider col) 
	{
		Destroy (col.gameObject);
	}
}
