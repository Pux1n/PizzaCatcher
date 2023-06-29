using UnityEngine;
using System.Collections;

public class timeDestroyer : MonoBehaviour {

	//how long GameObject will stay in the scene
	public float aliveTimer;

	//the funktion will be executed once at beginn
	void Start () {
		//Destroy funktion will delete gameObject (current GameObject) from the scene after aliveTimer seconds
		Destroy (gameObject, aliveTimer);
	}
} 