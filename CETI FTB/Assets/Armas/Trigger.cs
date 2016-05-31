using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public GameObject[] Armas; 
	public static int actual = 0; // 0 = ninguna

	void Start () {
	
	}
	
	void Update () {
		//if (Input.GetKeyDown ("space"))
			//soltar ();
	}

	void OnTriggerEnter (Collider Check) {
		if (Check.tag == "Player") {
			this.gameObject.SetActive (false);
			actual = Random.Range (1, Armas.Length);
		}
	}
	/*
	public void soltar () {
		GameObject carro = CargarCarro.getCarro();
		GameObject cactus = Instantiate (Armas [actual], carro.transform.position, carro.transform.rotation) as GameObject;
		actual = 0;
	}

	public void aventar () {
		GameObject carro = CargarCarro.getCarro();
		GameObject lanzar = Instantiate (Armas [Trigger.actual], carro.transform.position, carro.transform.rotation) as GameObject;
		// ? :c lanzar.rigidbody.AddForce (transform.forward * 2000 * 3);
	}*/
}
