using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public GameObject[] Armas; 
	public GameObject PlayerPrefab;
<<<<<<< HEAD
<<<<<<< HEAD
	public static int actual = -1; // -1 = ninguna
=======
=======
>>>>>>> feee2728477daf21a6035c1c6539c1263a92cb1c
	public static int actual = 0; // 0 = ninguna
>>>>>>> feee2728477daf21a6035c1c6539c1263a92cb1c

	void Start () {
	}
	
	void Update () {
<<<<<<< HEAD
<<<<<<< HEAD
		if (Input.GetKeyDown ("space") && actual >= 0) {
			/*if (actual == 2)
				soltar ();
			else
				aventar ();*/
			soltar ();
		}
=======
		if (Input.GetKeyDown ("space") && actual != 0)
			soltar ();
>>>>>>> feee2728477daf21a6035c1c6539c1263a92cb1c
=======
		if (Input.GetKeyDown ("space") && actual != 0)
			soltar ();
>>>>>>> feee2728477daf21a6035c1c6539c1263a92cb1c
	}

	void OnTriggerEnter (Collider Check) {
		if (Check.tag == "Player" || Check.tag == "IA") {
			this.gameObject.SetActive (false);
			actual = Random.Range (0, Armas.Length);
			Debug.Log (actual);
		}
	}

<<<<<<< HEAD
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
<<<<<<< HEAD
		GameObject arma = Instantiate (Armas [actual], PlayerPrefab.transform.position, Quaternion.identity) as GameObject;
		arma.SetActive (true);
		actual = -1;
=======
=======
	public void soltar () {
>>>>>>> feee2728477daf21a6035c1c6539c1263a92cb1c
		GameObject arma = Instantiate (Armas [2], PlayerPrefab.transform.position, Quaternion.identity) as GameObject;
		arma.SetActive (true);
		arma.AddComponent<MeshFilter> ();
		actual = 0;
>>>>>>> feee2728477daf21a6035c1c6539c1263a92cb1c
	}
	/*
	public void aventar () {
		GameObject arma = Instantiate (Armas [actual], PlayerPrefab.transform.position, Quaternion.identity) as GameObject;
		arma.GetComponent<Rigidbody>().AddForce (arma.transform.forward * 5);
		//arma.AddForce (direccion * 15f, ForceMode.Impulse);
		//arma.SetActive (true);
		actual = -1;
		// ? :c lanzar.rigidbody.AddForce (transform.forward * 2000 * 3);
	}
}
