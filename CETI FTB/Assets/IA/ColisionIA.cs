using UnityEngine;
using System.Collections;

public class ColisionIA : MonoBehaviour {

	GameObject[] karts;

	void Start () {
		karts = GameObject.FindGameObjectsWithTag ("IA");
		if (karts.Length == 0) {
			karts [0] = GameObject.FindGameObjectWithTag ("IAFinal");
		}
	}
	
	void Update () {
	}

	void OnCollisionEnter (Collision Check) {
		if (karts.Length == 1) {
			if (Check.collider.tag.Equals("Player"))
				this.GetComponent<hoMove> ().speed -= 3f;
		} else {
			if (Check.collider.tag.Equals ("Player")) {
				this.GetComponent<hoMove> ().speed -= 3f;
			} else if (Check.collider.tag.Equals ("IA") || Check.collider.tag.Equals ("arma")) {
				this.GetComponent<hoMove> ().speed -= Random.Range(3.0f, 5.0f);
			}
		}
	}
}
