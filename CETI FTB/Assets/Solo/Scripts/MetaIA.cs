using UnityEngine;
using System.Collections;

public class MetaIA : MonoBehaviour {

	void Awake () {
		this.gameObject.SetActive (true);
	}

	void Update () {

	}

	void OnTriggerEnter (Collider Check) {
		if (Check.tag == "IA") {
			Carreras.vueltaIA++;
		}
	}
}