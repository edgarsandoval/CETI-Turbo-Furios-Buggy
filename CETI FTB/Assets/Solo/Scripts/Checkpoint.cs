using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
	
	}

	void OnTriggerEnter (Collider Check) {
		if (Check.tag == "Player") {
			Carreras.vuelta++;	
		}
	}
}
