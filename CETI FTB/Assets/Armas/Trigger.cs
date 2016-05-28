using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {
	private float timer = 10.0f;

	void Start () {
	
	}
	
	void Update () {
		//Espera de 1 segundo
		timer--;
	}

	void OnTriggerEnter (Collider Check) {
		if (Check.tag == "Player") {
			this.enabled = false; //Desactiva la caja? :v
			timer = 10.0f;
		}
	}
}
