using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public GameObject SiguienteCheck;

	void Awake () {
		this.gameObject.SetActive (false);
	}

	void Update () {

	}

	void OnTriggerEnter (Collider Check) {
		if (Check.tag == "Player") {
			this.gameObject.SetActive (false);
			SiguienteCheck.SetActive (true);
		}
	}
}
