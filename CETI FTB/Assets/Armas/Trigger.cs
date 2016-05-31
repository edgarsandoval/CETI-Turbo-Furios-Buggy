using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public GameObject[] Armas; 
	public GameObject PlayerPrefab;
	public static int actual = 0; // 0 = ninguna

	void Start () {
	}
	
	void Update () {
		if (Input.GetKeyDown ("space") && actual != 0)
			soltar ();
	}

	void OnTriggerEnter (Collider Check) {
		if (Check.tag == "Player" || Check.tag == "IA") {
			this.gameObject.SetActive (false);
			actual = Random.Range (1, Armas.Length);
		}
	}

	public void soltar () {
		GameObject arma = Instantiate (Armas [2], PlayerPrefab.transform.position, Quaternion.identity) as GameObject;
		arma.SetActive (true);
		arma.AddComponent<MeshFilter> ();
		actual = 0;
	}
	/*
	public void aventar () {
		GameObject carro = CargarCarro.getCarro();
		GameObject lanzar = Instantiate (Armas [Trigger.actual], carro.transform.position, carro.transform.rotation) as GameObject;
		// ? :c lanzar.rigidbody.AddForce (transform.forward * 2000 * 3);
	}*/
}
