using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public GameObject[] Armas; 
	public GameObject PlayerPrefab;
	public static int actual = -1; // -1 = ninguna

	void Start () {
	}
	
	void Update () {
		if (Input.GetKeyDown ("space") && actual >= 0) {
			/*if (actual == 2)
				soltar ();
			else
				aventar ();*/
			soltar ();
		}
	}

	void OnTriggerEnter (Collider Check) {
		if (Check.tag == "Player" || Check.tag == "IA") {
			this.gameObject.SetActive (false);
			actual = Random.Range (0, Armas.Length);
		}
	}

	public static string getActual() {
		switch (actual) {
		default:
			return "";
			break;
		case 0:
			return "Micro";
			break;	
		case 1:
			return "HDD";
			break;
		case 2:
			return "Sancho";
			break;
		case 3:
			return "Aifon";
			break;

		}
		return "";
	}

	public void soltar () {
		GameObject arma = Instantiate (Armas [actual], PlayerPrefab.transform.position, Quaternion.identity) as GameObject;
		arma.SetActive (true);
		actual = -1;
	}
	/*
	public void aventar () {
		GameObject arma = Instantiate (Armas [actual], PlayerPrefab.transform.position, Quaternion.identity) as GameObject;
		arma.GetComponent<Rigidbody>().AddForce (arma.transform.forward * 5);
		//arma.AddForce (direccion * 15f, ForceMode.Impulse);
		//arma.SetActive (true);
		actual = -1;
		// ? :c lanzar.rigidbody.AddForce (transform.forward * 2000 * 3);
	}*/
}
