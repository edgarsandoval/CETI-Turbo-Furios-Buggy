using UnityEngine;
using System.Collections;

public class Meta : MonoBehaviour {

	public GameObject SiguienteCheck;

	void Awake () {
		this.gameObject.SetActive (true);
	}

	void Update () {
	
	}

	void OnTriggerEnter (Collider Check) {
		if (Check.tag == "Player") {
			Carreras.vuelta++;
			this.gameObject.SetActive (false);
			SiguienteCheck.SetActive (true);
		}
	}
}
